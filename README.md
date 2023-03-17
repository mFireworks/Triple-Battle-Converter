# Triple Battle Converter

## Overview

This tool is to automate the process of setting all the trainers within Pokemon Black 1, White 1, Black 2, and White 2 to triple battles. It doesn't do anything more than just setting the Battle Type flag in the usable trainers from whatever it is prior, to a triple battle.

### Required Tools

[Universal Pokemon Randomizer](https://github.com/Ajarmar/universal-pokemon-randomizer-zx/releases) - Used to randomize the game and set some of the flags that this tool doesn't set. (This tool does require java to run)

[Nitro Explorer 2](https://projectpokemon.org/home/files/file/2070-nitro-explorer/) - Used to extract compressed files from the game.

[NDS Editor (kiwi.ds)](https://projectpokemon.org/home/files/file/2073-nds-editor-kiwids/) - Used to decompressed the extracted files from the game.

### Optional Tools

[Kazo's B/W Tools](https://projectpokemon.org/home/forums/topic/13424-kazos-bw-tools/) - Not required to make everything triple battles, but the included trainer editor can be useful to ensure the tool worked.

## Usage

It's recommended the watch the following youtube video for clear instructions, but a written guide is provided below:

[Youtube Video](https://youtu.be/u326YDk3aJE)

1. Open the `Universal Pokemon Randomizer` and load your game into the tool. Most of the settings within here are fair game. Though there are two required settings to set.
   - Under `Foe Pokemon`, randomize the trainer's pokemon and check `Double Battle Mode`. This ensures that the trainer's AI is set to the multi-battle AI, so they won't attack their own pokemon.
   - Also under `Foe Pokemon`, check `Boss Trainers`, `Important Trainers`, and `Regular Trainers` under `Additional Pokemon for...`. Set the amount of pokemon to add to each group to a minimum of `2`. This will ensure that all trainers have at least 3 pokemon, which is required for the triple battles to activate.
   - While not required, it's also recommended to set the trainer and wild pokemon `Percentage Level Modifier` to around `+20%`, since you'll be getting a lot more experience with all the added pokemon, it should even out the level curve.

2. Once all your randomizer settings are set, hit `Randomize (Save)` to create your randomized game.

3. Now open `Nitro Explorer 2` and load your randomized game. Within here, you're going to extract the following file depending on which game you're modifying:
    - Black 1/White 1: Extract `a/0/9/2`, name the file `trdata.narc`.
    - Black 2/White 2: Extract `a/0/9/1`, name the file `trdata.narc`.

4. Now open `NDS Editor (kiwi.ds)` and drag your `trdata.narc` file into the window. Double click on the added entry to the list, check all files within the archive, and extract all files. This should create a folder named `trdata` within the same folder as `NDS Editor` with the specified number of files within it:
    - Black 1/White 1: 616 Files
    - Black 2/White 2: 814 Files

5. In your file explorer, open the newly created `trdata` folder and copy this folder's absolute path.

6. Now in the `Triple Battle Converter` folder, open the `run.bat` file and replace `ENTER-trdata-PATH-HERE` with the path that you just copied.

7. Save the `run.bat` and then double-click the file to run it. A command prompt should pop up with some information within it. If all went well, you should see **Modified 616/814 Trainers**. That means all the trainers are now triple battles!

8. Now reopen `NDS Editor (kiwi.ds)`, and in the toolbar, go `Tools > Make Narc File...`. In the upper field, select the path to the `trdata` folder that we just modified and click `OK`. You should now have a new `trdata.narc` file within the same folder as the `NDS Editor (kiwi.ds)`.

9. Now reopen `Nitro Explorer 2`, load your randomized game, and navigate to the same file that you extracted. Instead of extracting, you're now going to select `Reinsert`. Navigate to the `trdata.narc` file you've created and select it. The status bar at the bottom should now say `Reinserted 1/2 successfully`. Your game is now ready to play!

## Limitations

There are a handful of trainers in each game that aren't triple battles. This seemed by design from the Universal Randomizer, so I followed their example. They are the following:

Black 1/White 1: First battle against Cheren, Bianca, and N.
Black 2/White 2: First battle against Rival and Multi-Battle with old player character.

Also, it appears that most route trainer battles don't initiate if you don't have enough pokemon in your team to start the battle. Some scripted battles, like rival battles and gym battles still seem to work. Just ensure you have 3 non-fainted pokemon in your team at all times for full functionality.