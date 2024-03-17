using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using TripleBattleConverter2.src;

namespace TripleBattleConverter2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private int[] game1Omit = { 0, 53, 54, 55, 59, 60, 61, 64 }; // omit empty trainer, first rival fights, and first N fight. Same as universial randomizer
        private int[] game2Omit = { 0, 161, 162, 163, 342, 347, 356, 360, 361, 362, 363, 364, 365, 374, 375, 376, 377, 797, 798, 799 };     // omit empty trainer, first rival battle and required multi-battles

        public MainWindow()
        {
            InitializeComponent();
        }

        private void doBrowseFolder(object sender, RoutedEventArgs e)
        {
            OpenFolderDialog folderPicker = new OpenFolderDialog();
            bool? pickedDir = folderPicker.ShowDialog();
            if (pickedDir == true && folderPicker.FolderName.Length > 0)
            {
                PathField.Text = folderPicker.FolderName;
            }
        }

        private void sendError(string message)
        {
            MessageBox.Show(message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private long? checkFiles(string[] files)
        {
            long fileSize = 0;
            foreach (string filePath in files)
            {
                if (Path.GetExtension(filePath).Length != 0 && !Path.GetExtension(filePath).Equals(".bin"))
                {
                    return null;
                }
                var file = new FileInfo(filePath);
                fileSize += file.Length;
            }
            return fileSize;
        }

        private void doConvert(object sender, RoutedEventArgs e)
        {
            if (PathField.Text.Length > 0)
            {
                if (!Directory.Exists(PathField.Text))
                {
                    sendError("Folder doesn't exist.");
                    return;
                }
                if (Path.GetFileName(PathField.Text) != "trdata")
                {
                    sendError("The selected folder's name isn't \"trdata\". Make sure the folder is named \"trdata\" to confirm this is the folder you'd like to operate on.");
                    return;
                }
                string[] files = Directory.GetFiles(PathField.Text);
                long? fileSize = checkFiles(files);
                if (fileSize == null)
                {
                    sendError("Found file with an extension. trdata files shouldn't have an extension. Make sure you selected the right directory!");
                    return;
                }

                GameType game = new BW1();
                if (BW2.IsChecked == true)
                    game = new BW2();
                else if (XY.IsChecked == true)
                    game = new XY();
                else if (ORAS.IsChecked == true)
                    game = new ORAS();
                //else if (BW1.IsChecked == true)
                //    game = new BW1();

                switch (game.verifyFiles(files.Length, fileSize))
                {
                    case ErrorType.IncorrectFileSize:
                        sendError("The total file size for the trdata folder doesn't match what's expected for Black/White. Make sure you selected the right directory!");
                        return;
                    case ErrorType.IncorrectFileCount:
                        sendError("There's not 616 files within the trdata folder for Black/White. Make sure you selected the right directory!");
                        return;
                }
                game.omitTrainers(files);

                BattleType battleType = new TripleBattles();
                if (RotationBattles.IsChecked == true)
                    battleType = new RotationBattles();
                //else if (TripleBattles.IsChecked == true)
                //    type = new TripleBattles();

                foreach (string file in files)
                {
                    if (file.Length == 0)
                        continue;
                    try
                    {
                        BinaryReader reader = new BinaryReader(File.OpenRead(file));
                        reader.BaseStream.Seek(game.getAIOffset(), SeekOrigin.Begin);
                        byte currentAI = reader.ReadByte();
                        reader.Close();

                        BinaryWriter writer = new BinaryWriter(File.Open(file, FileMode.Open, FileAccess.ReadWrite));
                        writer.BaseStream.Seek(game.getBattleOffset(), SeekOrigin.Begin);
                        writer.Write(battleType.getBattleByte()); // Change fight from it's value to our new type.

                        writer.BaseStream.Seek(game.getAIOffset(), SeekOrigin.Begin);
                        writer.Write(battleType.convertTrainerAI(currentAI));
                        writer.Close();
                    } catch
                    {
                        sendError("Fail to process " + file + ". Make sure you've selected the right directory, you have read/write permissions to these files, and the files aren't open in another program.");
                        return;
                    }
                }
                MessageBox.Show("Processed " + files.Length + " trainers.", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                sendError("No Folder Specified.");
            }
        }
    }
}