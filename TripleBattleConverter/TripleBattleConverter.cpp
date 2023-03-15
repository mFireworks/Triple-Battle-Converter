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

    if (totalSize != 16276 || filePaths.size() != 814) {
        std::cout << "The size of the files doesn't equal the expected amount in Black 2. Ensure you extracted the right data.";
        return 0;
    }

    // omit empty trainer, first rival battle and required multi-battle
    for (const size_t omitIndex : { 0, 161, 162, 163, 360, 361, 362, 363, 364, 365 }) {
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