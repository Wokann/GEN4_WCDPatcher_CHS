
namespace WCDPatcher.Core.WondercardPatcher
{
    /// <summary>
    /// Location of offsets used in patching the wondercard. All offsets in this class are relative to the start of the wondercard
    /// </summary>
    public static class WondercardOffsets
    {
        /// <summary>
        /// The value that determines what games can accept the wondercard (Size: 2 bytes)
        /// </summary>
        public const int PCDHeader_GameAllowanceBlock = 0x0000014C;

        /// <summary>
        /// The GGID offset. Used for determining region for distribution (Language based; Size: 4 bytes)
        /// </summary>
        public static int GGID = 0x168C00;  //4 bytes


        /// <summary>
        /// The offset where the friend distribution limit resides
        /// </summary>
        public static int FriendDistributionLimit = 0x00000348;

        /// <summary>
        /// The offset to copy wondercard header info from. (Size: 80 bytes;Dest: Wondercard)
        /// </summary>
        public static int SourceCopyBlock = 0x104; //80 bytes,WCARD


        /// <summary>
        /// The date distribution offset. (Size: 8 bytes;Format: Unknown)
        /// </summary>
        public static int DateDistributionOffsetStart = 0x16C600; //8 Bytes, unknown date format

        public const int _PCDType = 0x00; // 1 byte long
        public const int _PCDCommentLocation = 340;
        public const int _PCDCommentLength = 0x1EC;
        public const int _PCDCardTitle = 260;
        public const int _PCDCardTitleLength = 0x48;
        public const int _PCDIconOne = 0x34a;
        public const int _PCDIconTwo = 0x34c;
        public const int _PCDIconThree = 0x34e;
        public const int _PCDPokemonFile = 8; // 0x08 -> 0xF3 for PKM file (my version), 0x08 -> 0xec for compliant export
        public const int _PCDReceivedDate = 0x354;
        public const int _PCDValue = 4;
        public const int _PCDWonderCardNumber = 0x150;
    }
}
