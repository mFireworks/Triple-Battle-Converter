# Triple Battle Converter

## Overview

This tool is to automate the process of setting all the trainers within Pokemon Black 1, White 1, Black 2, and White 2 to triple battles. It doesn't do anything more than just setting the Battle Type flag in the usable trainers from whatever it is prior, to a triple battle.

These instructions are made for solely the Gen 5 Pokemon games. While support for gen 6 is there, it's a bit of a different process.

## Disclaimer

This program modifies files within a folder at the binary level. Incorrect usage of this tool can lead to potential data corruption. There are a number of checks in place to mitigate the chances of this occurring, but use this tool at your own risk.

### Required Tools

**For All Versions**

[Universal Pokemon Randomizer](https://github.com/Ajarmar/universal-pokemon-randomizer-zx/releases) - Used to randomize the game and set some of the flags that this tool doesn't set. (This tool does require java to run)

[.NET 8](https://dotnet.microsoft.com/en-us/download) - This tool is written in C#, which requires the .Net Runtime to be installed on your machine. This link should provide the download that fits your OS and processor.

**For Generation 5**

[Nitro Explorer 2](https://projectpokemon.org/home/files/file/2070-nitro-explorer/) - Used to extract compressed files from the game.

[NDS Editor (kiwi.ds)](https://projectpokemon.org/home/files/file/2073-nds-editor-kiwids/) - Used to decompressed the extracted files from the game.

**For Generation 6**

[DotNet 3DS Toolkit](https://github.com/evandixon/DotNet3dsToolkit/releases/tag/1.4.6) - Used to extract compressed files from the game.

[GARCTool](https://github.com/kwsch/GARCTool/releases/tag/1.3a) - Used to decompress the extracted files from the game.

### Optional Tools

[Kazo's B/W Tools](https://projectpokemon.org/home/forums/topic/13424-kazos-bw-tools/) - Not required to make everything triple battles, but the included trainer editor can be useful to ensure the tool worked for the generation 5 games.

[pk3DS](https://projectpokemon.org/home/forums/topic/34377-pk3ds-pok%C3%A9mon-3ds-rom-editor-and-randomizer/) - Not required, but will allow you to view the game's information to ensure the tool worked for the generation 6 games.

## Usage

It's recommended the watch the following youtube video for clear instructions, but a written guide is provided below:

[Youtube Video](https://www.youtube.com/watch?v=u3LQNY04gO8&lc) - For Generation 5 Games

### All Generations

1. Open the `Universal Pokemon Randomizer` and load your game into the tool. Most of the settings within here are fair game. Though there are two required settings to set.
   - Under `Foe Pokemon`, randomize the trainer's pokemon and check `Double Battle Mode`. This ensures that the trainer's AI is set to the multi-battle AI, so they won't attack their own pokemon.
   - Also under `Foe Pokemon`, check `Boss Trainers`, `Important Trainers`, and `Regular Trainers` under `Additional Pokemon for...`. Set the amount of pokemon to add to each group to a minimum of `2`. This will ensure that all trainers have at least 3 pokemon, which is required for the triple battles to activate.
   - While not required, it's also recommended to set the trainer and wild pokemon `Percentage Level Modifier` to around `+20%`, since you'll be getting a lot more experience with all the added pokemon, it should even out the level curve.

2. Once all your randomizer settings are set, hit `Randomize (Save)` to create your randomized game.

### Generation 5

3. Now open `Nitro Explorer 2` and load your randomized game. Within here, you're going to extract the following file depending on which game you're modifying:
    - Black 1/White 1: Extract `a/0/9/2`, name the file `trdata.narc`.
    - Black 2/White 2: Extract `a/0/9/1`, name the file `trdata.narc`.

4. Now open `NDS Editor (kiwi.ds)` and drag your `trdata.narc` file into the window. Double click on the added entry to the list, check all files within the archive, and extract all files. This should create a folder named `trdata` within the same folder as `NDS Editor` with the specified number of files within it:
    - Black 1/White 1: 616 Files
    - Black 2/White 2: 814 Files

5. Now in the Triple Battle Converter folder, double-click on `TripleBattleConverter2.exe` and a small window should pop-up.

6. Within the window, click on the `Browse...` button and navigate to the newly created `trdata` folder. Select it and click `Select Folder`.

7. Select which game you're converting below, and then click the `Convert` button.
   If all went well, you should see a window pop-up with **Modified 616/814 Trainers** inside. That means all the trainers are now triple battles!

8. Now reopen `NDS Editor (kiwi.ds)`, and in the toolbar, go `Tools > Make Narc File...`. In the upper field, select the path to the `trdata` folder that we just modified and click `OK`. You should now have a new `trdata.narc` file within the same folder as the `NDS Editor (kiwi.ds)`.

9. Now reopen `Nitro Explorer 2`, load your randomized game, and navigate to the same file that you extracted. Instead of extracting, you're now going to select `Reinsert`. Navigate to the `trdata.narc` file you've created and select it. The status bar at the bottom should now say `Reinserted 1/2 successfully`. Your game is now ready to play!

### Generation 6

3. Now open `DotNet 3DS Toolkit`, which is with `ToolkitForm.exe`. Under the `Extract` tab, set the following fields:
    - For the `Source ROM`, browse for your randomized generation 6 game.
    - For the `Output Directory`, create a new folder on your desktop for ease of access and select that as the destination.
    - For the `Options`, leave `Auto` selected.

4. Now click the `Extract` button. It might take a while, but it'll eventually say `Ready` in the bottom-left corner for once it's completed.

5. Now open `GARCTool` and select `Open File`. Browse within your new folder into the `RomFS` folder and navigate to the file of your game:
    - X/Y: Extract `a/0/3/8`.
    - Omega Ruby/Alpha Sapphire: Extract `a/0/3/6`.

6. Extract the selected file. It should say that it unpacked X amount of files from the GARC:
    - X/Y: 785 Files
    - Omega Ruby/Alpha Sapphire: 950 Files

7. Navigate to that directory you just extracted the files out of and you should see a folder named `#_`, rename this folder to `trdata`.

8. Now in the Triple Battle Converter folder, double-click on the Triple Battle Converter tool pertaining to your OS and a small window should pop-up.

9. Within the window, click on the `Browse...` button and navigate to the newly renamed `trdata` folder. Select it and click `Select Folder`.

10. Select which game you're converting below, select what type of battle you'd like, then click the `Convert` button.
   If all went well, you should see a window pop-up with **Modified 785/950 Trainers** inside. That means all the trainers are now converted!

11. Now go back to the `GARCTool` and select `Open Folder`. Browse to your modified `trdata` folder, select it, and click process.

12. Navigate back to this directory, and you should see a `trdata.garc` file within. Delete your `trdata` folder and the original garc file. Rename this `trdata.garc` file to the original.

13. Now go back to the `DotNet 3DS Toolkit` and go to the `Build` tab. The settings within this tab should be as followed:
    - For the `Source Directory`, browse to the new folder that you created on your desktop.
    - For the `Output ROM`, browse to where you'd like the finished ROM to go and give it a name.
    - For the `Output ROM Format`, select `0-Key Encrypted CCI (for Gateway)`.

14. Now click the `Build` button and a new window should pop-up showing the rebuilding process. Once that's complete, you're done building your game!

## Limitations

There are a handful of trainers in each game that aren't triple battles. This seemed by design from the Universal Randomizer, so I followed their example. They are the following:

- Black 1/White 1: First battle against Cheren, Bianca, and N.
- Black 2/White 2: First battle against Rival and Multi-Battles throughout the game.
- X/Y: First Rival Fight, the battle for the Mega Ring, and some others I'm not too sure of.
- Omega Ruby/Alpha Sapphire: First Rival Fight

Also, it appears that most route trainer battles don't initiate if you don't have enough pokemon in your team to start the battle. Some scripted battles, like rival battles and gym battles still seem to work. Just ensure you have 3 non-fainted pokemon in your team at all times for full functionality.