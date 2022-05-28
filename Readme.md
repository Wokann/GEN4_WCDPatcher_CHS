Wondercard Distribution Patcher 1.4 by MicShadow

1.45由卧看微尘简中汉化

========== 你需要的准备的东西 ===========
- 1 个 2008代欧奇希斯配信卡带的纯净dump ROM (MD5: CC30A203C5489440EA2315DB3C791866)
- 1个有效的神秘卡片配信卡文件 (后缀.pcd, 856 bytes, 可在db.pokesav.org查阅)
- .NET Framework 2.0

========== 如何使用自制配信器 ========
1) 选择代欧奇希斯官方配信文件(.nds)
2) 选择有效的神秘卡片配信卡文件(pcd)
3) 选择打完补丁生成的ROM存放的位置
4) 为新生成的NDS命名标题 (游戏标题，最大12字符)
如果不更改，将保持原状 DEOXYS2008
5) 点击“打补丁”按钮

========== 游戏ID ===========
你可以手动输入十六进制字节来设置游戏版本的限制。
你需要将允许配信的游戏id的十六进制值累加起来。
现有已知的游戏id为：
钻石 = 0004
珍珠 = 0008
白金 = 0010
魂银 = 0001
心金 = 8000

你需要将选中的游戏版本的id累加起来，可以使用Windows系统自带的计算器，有十六进制模式运算。其他可用的计算工具也均可。

如: 
想制作仅允许钻石和心金接收配信的，需要
钻石 (0004) + 心金 (8000)
0004+8000 = 8004 (十六进制)

全版本均可接收即是:
0004+0008+0010+0001+8000 = 801D

========== 更新日志 ============

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


========== 命令行设置 ==========
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

========== 白金兼容性 =========

本自制配信器完全兼容白金。

========== 控制符 =============

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

========== 批量补丁 ============

本版本添加了批量补丁功能。
首先设置好参数(以及控制符，如有)
Then, press the B button. Select a directory to search for Wondercards in
The function will then create a new distro for p/
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
