
namespace WCDPatcher.Core.WondercardPatcher
{
   public static class WondercardData
    {
        /// <summary>
        /// The date distribution range start offset
        /// </summary>
        public static byte[] DistributionDateStart = { 0x00, 0x00, 0x00, 0x00 }; // Format is YY,??,MM,DD (in hex)
        /// <summary>
        /// The distribution range second start offset
        /// </summary>
        public static byte[] DistributionDateEnd = { 0xFF, 0xFF, 0xFF, 0xFF }; //Unlimited end date. Format is same as dist_date_start

        public static byte[] GGID_English = { 0x18, 0x03, 0x40, 0x00 };
        public static byte[] GGID_French = { 0xCD, 0x00, 0x80, 0x00 };
        public static byte[] GGID_Italian = { 0xCF, 0x00, 0x80, 00 };
        public static byte[] GGID_Spanish = { 0xD0, 0x00, 0x80, 0x00 };
        public static byte[] GGID_Japanese = { 0x45, 0x03, 0x00, 0x00 };
        public static byte[] GGID_Korean = { 0x18, 0x00, 0xC0, 0x00 };
        public static byte[] GGID_German = {0xCE, 0x00, 0x80, 0x00  };

        
    }
}
