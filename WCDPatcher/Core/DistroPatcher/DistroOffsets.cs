
namespace WCDPatcher.Core.DistroPatcher
{   
    /// <summary>
    /// The offsets for data to be placed into. All offsets here are relative to the distro file (.nds)
    /// </summary>
    public static class DistroOffsets
    {
        public struct DescriptionOffsets
        {
            /// <summary>
            /// The Japanese description banner offset
            /// </summary>
             public static int jap_desc = 0x00045440,
                /// <summary>
                /// The English description banner offset
                /// </summary>
            eng_desc = 0x00045540,
                /// <summary>
                /// The French description banner offset
                /// </summary>
            frn_desc = 0x00045640,
                /// <summary>
                /// The German description banner offset
                /// </summary>
            ger_desc = 0x00045740,
                /// <summary>
                /// The Italian description banner offset
                /// </summary>
            ita_desc = 0x00045840,
                /// <summary>
                /// The Spanish description banner offset
                /// </summary>
            spn_desc = 0x00045940;
        }



        public struct CRC_Offsets
        {
            /// <summary>
            /// The offset where the Banner CRC is written
            /// </summary>
            public static int BannerCRCOffset = 0x00045202, // 2 bytes
                /// <summary>
                /// The offset where the Header CRC is written
                /// </summary>
            HeaderCRCOffset = 0x15E; //2 bytes

            
        }

        /// <summary>
        /// The position of the wondercard inside the distro. (Size: 856 bytes)
        /// </summary>
        public static int WonderCardPosition = 0x05DD50; //856 bytes

        /// <summary>
        /// The location for two zeroes inside the distro. (Size: 2 bytes)
        /// </summary>
        public static int TwoZerosOffset = 0x05E0A4; //2 bytes

        /// <summary>
        /// The header info offset inside the rom. location 1 (Size: 80 bytes)
        /// </summary>
        public static int HeaderDestinationOne = 0x05DC10; //80 bytes

        /// <summary>
        /// The header info offset inside the rom. location 2 (Size: 80 bytes)
        /// </summary>
        public static int HeaderDestinationTwo = 0x05DD00; //80 bytes

    }
}
