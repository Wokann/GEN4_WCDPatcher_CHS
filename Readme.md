Wondercard Distribution Patcher 1.4 by MicShadow
1.45由卧看微尘简中汉化

========== What You Will Need ===========
- 1 clean ROM dump of Deoxys Distribution Cart 2008 (MD5: CC30A203C5489440EA2315DB3C791866)
- A valid wondercard file (.pcd, 856 bytes, found on db.pokesav.org)
- .NET Framework 2.0

========== How to use the patcher ========
Its pretty self explanatory, but anyway:

1) Select your Deoxys distro (nds) file
2) Select the valid wondercard file (pcd)
3) Select the new loction for the patched NDS file
4) Select a title for the new NDS (The game title, maximum 12 characters)
If the title remains blank, it will stay as DEOXYS2008
5) Click the patch button

========== Hex Game ID's ===========
It is possible to set your own custom game restrictions, using manually entered
hex characters. To combine games, you must add the hex values together
the known game ID's are:

Diamon = 0004
Pearl = 0008
Platinum = 0010
Pokemon SoulSilver = 0001
Pokemon HeartGold = 8000

These are hex values, so you will need to add them together as hex values
The Windows 7/Vista calculator has a 'Programmer' mode, which has a hex setting within it

To change to hex mode in the calculator, Select View from the top menu, and select Programmer
Make sure the Hex button is selected on the left, and then add the above values together to
create your own custom game settings

You can use any tool that accepts hex to create custom game restrictions

For example: 
To make a custom restriction that only allows Diamond and HeartGold to recieve wondercards, use
Diamond (0004) + Pokemon HeartGold (8000)
0004+8000 = 8004 (in hex)

All the games together would be:
0004+0008+0010+0001+8000 = 801D

========== Changelog ============

1.45
-更改为简体中文

1.44a
-Removed the Nintendo Logo CRC generation, it's also never changed
-Program now terminates correctly, bug present in all past versions
-No longer requires admin privleges to run

1.44
-Removed the (unencrypted) Secure CRC generation, it gives a white screen in newer
versions of AKAIO and this area of the rom is never modified anyway.
-Added option to not change the game distribution setting from the original .pcd
-Fixed zero out 'date recieved' introduced in 1.43b so it actually works
-Reduced the size of the .exe by about 70% by using standard Windows icon sizes
(note: unofficial version by arablizzard2413)

1.43b
-Made the patcher zero out the 'date recieved' data before patching

1.43
-Removed the 'local only' options, in light of information given by TM2-Megatron
-Rewrote backend code to make slightly faster and make upgrades easier

1.41
-Added 'session seed', so you can get the same card twice by slightly altering the wondercard header
(note: leave as 0 if you dont want to change it)
-Added support for Japanese version of HeartGold and SoulSilver

1.4
-Reworked entire codebase
-Reworked main UI
-Added more error checking
-Added friend distribution checking
-Added complete CRC fix patch
-Added 'Local only' distribution patching

1.3

-Added batch functionality
-Added macro functionality
-Added custom game ID regions

1.21
Fixed a platinum bug, as well as a cosmetic one

1.2

-Added full Platinum support
-Added ROM description editing
-Slight GUI changes
-Rewrite of certain UI elements code

1.1

-Fixed the 'Mystery From Space' bug

1.0 
-Inital release


========== Command Line Options ==========
-ohash					Overrides hash checking to allow for a different hash on the distro rom
-s					Silent mode. Produces no dialogs for auto patching
-nogui					After completing the command line switches, exits the program, rather than showing the GUI. Best used with -s and -ohash
-wcard [wondercard location]		Specifies a wondercard for the autopatching option
-dist [distribution rom]		Specifies the distribution rom for the autopatching option
-region [region]			Choices are English, French, Italian, Korean, Spanish and Japanese. The region for the distributed rom
-nrom [new file path]			Specifies the new location for the autopatching option
-title [12 character string]		Specifies the new NDS ROM title
-dodirdef [directory]			Specifies a directory to loop, select all wondercards and make distro roms out of. (Uses default settings currently)
-desclang [description_language]	Specifies the language to change the description for. Same options as -region (excepting Korean)
-desc [description]			Specifies the description for the ROM banner information (shown on flashcart menus)
-ap					Starts the autopatching (not needed for -dodirdef)

NOTE: command line option updates will only be occasional, as interest is limited to myself it seems

========== Platinum Compatibility =========

Platinum is fully compatible with this patcher

========== Macros =============

Macros are supported in this version, in all of the text fields minus game version field and Wondercard file
The macros are:

%t = Internal ROM title (12 characters)

%l = Original distro language

%d = Original ROM description

%n = Original ROM name (Description title)

%c = Original ROM company

%f = Wondercard parent directory name

%w = Wondercard name (minus extension)

e.g. (%l) %t - %c (%w)
would equal on a English cart:
(English) Deoxys Distribution 2008 - Nintendo (ALAMOS-DARKRAI-PKM-DB)

========== Batch capability ============

A batch patching function GUI was added to this version.
To use it, type all values like an individual patch (with macros, if required) except for Wondercard file
Then, press the B button. Select a directory to search for Wondercards in
The function will then create a new distro for each wondercard found

========== Game Version ID =============



NOTE: You can enter your own ID's directly into the program without needing to edit the Wondercard
Simply enter a two byte value in hex (e.g. 000C) to use this function

More ID's may be supported in the future, but for now just refer to the discussion thread (see Credits) for more ID's

Any problems? see this section

=========== Troubleshooting ===========

Q) Another generic error occured while trying to patch the file, what should I do?
A) Make sure you have write and read access on the application location, and that the input files are correct

Q) Whenever I try to recieve the wondercard gift, it says I have already recieved this gift before. What gives?
A) 1.1 rectifies this bug. Version 1 had this problem. If this bug still occurs for you, let me know

Q) Where do I get the distribution rom?
A) I cant help you with this part, it's up to you. Google is your friend
hint: Deoxys Distributon Cart 2008

Any other bugs you find, please PM the information to me (MicShadow at GBATemp.net) or reply in the program thread

=========== Source =============

The source is included in this version
With the recent backend rewrite,the code is rewritten in a neat and modular layout
Not all functions have descriptions however

It is C# .NET 2.0, the project file is currently in C# 2010 Express Beta 2 format, but the code itself is .NET 2.0 written

=========== Credits ============
The original patching thread on GBATemp.net (http://gbatemp.net/index.php?showtopic=92283&st=15)
The testers/users who reported the card ID bug (Thanks jruschme!)
TM2-Megatron and AlexMoron for help with testing
Pokesav creators, for creating a wondercard editor which i used for reference
TM2-Megatron again, for providing insight into the 'local only' options
Rockman GFF for the info on using the wondercards on Platinum 
Crystal - Project Icons iconpack. (uses the IRKick icon)
Cracker, for making the first command line patcher and providing valuable information
Darkfader, for his work on the internal DS CRC operations
Marcel de Wijs, for his useful CRCTool C# class
artic_flame, for almost getting to the patcher
and of course Chamillionaire for providing the offset information
