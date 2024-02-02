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

namespace TripleBattleConverter2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private int[] game1Omit = { 0, 53, 54, 55, 59, 60, 61, 64 }; // omit empty trainer, first rival fights, and first N fight. Same as universial randomizer
        private int[] game2Omit = { 0, 161, 162, 163, 360, 361, 362, 363, 364, 365 };     // omit empty trainer, first rival battle and required multi-battle

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
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
                int fileCount = files.Length;
                long fileSize = 0;
                foreach (string filePath in files)
                {
                    if (Path.GetExtension(filePath).Length != 0)
                    {
                        sendError("Found file with an extension. trdata files shouldn't have an extension. Make sure you selected the right directory!");
                        return;
                    }
                    var file = new FileInfo(filePath);
                    fileSize += file.Length;
                }
                if (Game1.IsChecked == true)
                {
                    if (fileSize != 12316)
                    {
                        sendError("The total file size for the trdata folder doesn't match what's expected for Black/White. Make sure you selected the right directory!");
                        return;
                    }
                    if (files.Length != 616)
                    {
                        sendError("There's not 616 files within the trdata folder for Black/White. Make sure you selected the right directory!");
                        return;
                    }

                    foreach (int omit in game1Omit)
                        files[omit] = "";
                }
                else if (Game2.IsChecked == true)
                {
                    if (fileSize != 16276)
                    {
                        sendError("The total file size for the trdata folder doesn't match what's expected for Black 2/White 2. Make sure you selected the right directory!");
                        return;
                    }
                    if (files.Length != 814)
                    {
                        sendError("There's not 814 files within the trdata folder for Black 2/White 2. Make sure you selected the right directory!");
                        return;
                    }

                    foreach (int omit in game2Omit)
                        files[omit] = "";
                }

                foreach (string file in files)
                {
                    if (file.Length == 0)
                        continue;
                    try
                    {
                        BinaryWriter writer = new BinaryWriter(File.Open(file, FileMode.Open, FileAccess.ReadWrite));
                        writer.BaseStream.Position = 0x02;
                        writer.Write(0x02);
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