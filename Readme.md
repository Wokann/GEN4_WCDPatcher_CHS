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

文本控制符,可在除神秘卡片和目标游戏字段之外的所有字段中使用。
控制符列表:

%t = 内部ROM标题（12个字符）

%l = 原始发行语言

%d = 原始ROM描述

%n = 原始ROM名称（描述标题）

%c = 原始ROM公司

%f = 神秘卡片上级菜单名称

%w = 神秘卡片名称（减去扩展）

e.g. (%l) %t - %c (%w)
在英语卡带上将等同:
(English) Deoxys Distribution 2008 - Nintendo (ALAMOS-DARKRAI-PKM-DB)

========== 批量补丁 ============

本版本添加了批量补丁功能。
首先设置好参数(以及控制符，如有)
然后，按B按钮。 选择一个目录以搜索神秘卡片配信卡文件
然后，该功能将为其生成新的ROM p/
========== 游戏版本 ID =============


注意：您可以将自己的ID直接输入到程序中，而无需编辑WonderCard
只需在十六进制（例如000C）中输入两个字节值即可使用此功能

将来可能会支持更多ID，但现在只参考讨论线程（请参阅信用）。

任何问题？ 请参阅本节

=========== 故障排除 ===========

Q) 试图修补文件时发生了另一个通用错误，我该怎么办？

A) 确保您在应用程序位置上有写入和阅读访问权限，并且输入文件是正确的。


Q) 每当我尝试接收神秘礼物时，它说我以前已经收到了这份礼物。 谁给的？

A) 1.1纠正此错误。 版本1有这个问题。 如果此错误仍然适合您，请告诉我。


Q) 我在哪里获得官方配信发行rom？

A) 我无法帮助您完成这一部分，这取决于您。 Google是你的好朋友。

提示: Deoxys Distributon Cart 2008


您发现的任何其他错误，请向我提供信息（gbatemp.net的micshadow）或在程序线程中回复。

=========== 资源 =============

源包含在此版本中
随着最近的后端重写，该代码以整洁而模块化的布局重写
并非所有功能都有描述

它是C＃.NET 2.0，该项目文件当前在C＃2010 Express Beta 2格式中，但代码本身为.NET 2.0书面

=========== Credits ============

The original patching thread on GBATemp.net (http://gbatemp.net/index.php?showtopic=92283&st=15)

报告神秘卡片ID错误的测试人员/用户（感谢Jruschme！）

TM2-Megatron和Alexmoron进行测试

Pokesav Creators，用于创建一个神秘卡片编辑器，我用于参考

再次提供TM2-Megatron，以提供对“本地唯一”选项的见解

Rockman GFF获取有关使用白金的神秘卡片的信息

Crystal - 项目图标图标。 （使用irkick图标）

Cracker, 用于制作第一个命令行修补程序并提供有价值的信息

Darkfader, 他在内部DS CRC操作上的工作

Marcel de Wijs, 他那非常有用的crctool c＃class

artic_flame, 几乎到了Patcher

当然还有 Chamillionaire 提供偏移信息
