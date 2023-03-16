#include <filesystem>
#include <fstream>
#include <iostream>
#include <string>
#include <vector>

int main(int argc, char* argv[]) {
    std::vector<std::string> argList(argv + 1, argv + argc);
    if (argList.empty()) {
        std::cout << "No directory path given. Specify path to folder containing all extracted trainer data.";
        return 0;
    }

    std::filesystem::path trdataPath(argList.at(0));
    if (!std::filesystem::exists(trdataPath) || std::filesystem::is_empty(trdataPath) || !std::filesystem::is_directory(trdataPath)) {
        std::cout << "Path given wasn't to a directory. Specify path to folder containing all extracted trainer data.";
        return 0;
    }

    if (trdataPath.filename().string() != "trdata") {
        std::cout << " The folder name isn't \"trdata\". Make sure the folder is named \"trdata\" to confirm you want to modify the files within.";
        return 0;
    }

    std::vector<std::filesystem::path> filePaths = {};
    std::uintmax_t totalSize = 0;
    for (const auto& entry : std::filesystem::directory_iterator(argList.at(0))) {
        filePaths.push_back(entry.path());
        totalSize += entry.file_size();
    }

    const bool isBW1 = totalSize == 12316 && filePaths.size() == 616;
    const bool isBW2 = totalSize == 16276 && filePaths.size() == 814;
    if (!isBW1 && !isBW2) {
        std::cout << "The size of the files doesn't equal the expected amount. Ensure you extracted the right data.\n";
        std::cout << "The only games supported are Black, White, Black 2, and White 2\n";
        return 0;
    }

    std::vector<size_t> omitSet;
    if (isBW1)
        omitSet = { 0, 53, 54, 55, 59, 60, 61, 64 }; // omit empty trainer, first rival fights, and first N fight. Same as universial randomizer
    else
        omitSet = { 0, 161, 162, 163, 360, 361, 362, 363, 364, 365 };     // omit empty trainer, first rival battle and required multi-battle

    for (const size_t omitIndex : omitSet) {
        filePaths.at(omitIndex).clear();
    }
    
    for (const auto& filePath : filePaths) {
        if (filePath.empty())
            continue;
        std::fstream trainerData(filePath, std::ios::in | std::ios::out | std::ios::binary);
        if (!trainerData) {
            std::cout << "File " << filePath.string() << " failed to be opened for read and write. Be sure to have the file closed before running this program.";
            return 0;
        }
        if (trainerData.fail()) {
            std::cout << "File " << filePath.string() << " failed to be opened for read and write. Be sure to have the file closed before running this program.";
            return 0;
        }
        trainerData.seekp(0x02);
        trainerData << char(0x02);
        if (trainerData.fail()) {
            std::cout << "File " << filePath.string() << " failed to be written to. Be sure to have the file closed before running this program.";
            return 0;
        }
        trainerData.close();
    }

    std::cout << "Modified " << filePaths.size() << " trainers.";
}