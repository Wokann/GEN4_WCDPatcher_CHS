
namespace WCDPatcher.Core.PCDReaders
{
   public static class InternalPCDMetaDataReader
    {
       public static string GetWonderCardRegion(string pcdPath)
       {
           byte[] tmp = IO.Patcher.ReadDataFromFile(pcdPath, WondercardPatcher.WondercardOffsets.GGID
               , 4, 0);

       

           if (IO.ByteTools.IsByteArrayEqual(tmp, WondercardPatcher.WondercardData.GGID_English)) return "英语";
           if (IO.ByteTools.IsByteArrayEqual(tmp, WondercardPatcher.WondercardData.GGID_French)) return "法语";
           if (IO.ByteTools.IsByteArrayEqual(tmp, WondercardPatcher.WondercardData.GGID_Italian)) return "意大利语";
           if (IO.ByteTools.IsByteArrayEqual(tmp, WondercardPatcher.WondercardData.GGID_Japanese)) return "日语";
           if (IO.ByteTools.IsByteArrayEqual(tmp, WondercardPatcher.WondercardData.GGID_Korean)) return "韩语";
           if (IO.ByteTools.IsByteArrayEqual(tmp, WondercardPatcher.WondercardData.GGID_Spanish)) return "西班牙语";

           return "";
       }
       public static string GetWonderCardRegion(byte[] GGID)
       {
           byte[] tmp = GGID;

           if (IO.ByteTools.IsByteArrayEqual(tmp, WondercardPatcher.WondercardData.GGID_English)) return "英语";
           if (IO.ByteTools.IsByteArrayEqual(tmp, WondercardPatcher.WondercardData.GGID_French)) return "法语";
           if (IO.ByteTools.IsByteArrayEqual(tmp, WondercardPatcher.WondercardData.GGID_Italian)) return "意大利语";
           if (IO.ByteTools.IsByteArrayEqual(tmp, WondercardPatcher.WondercardData.GGID_Japanese)) return "日语";
           if (IO.ByteTools.IsByteArrayEqual(tmp, WondercardPatcher.WondercardData.GGID_Korean)) return "韩语";
           if (IO.ByteTools.IsByteArrayEqual(tmp, WondercardPatcher.WondercardData.GGID_Spanish)) return "西班牙语";

           return "";
       }
    }
}
