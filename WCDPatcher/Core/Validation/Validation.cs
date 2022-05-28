
using System.IO;
namespace WCDPatcher.Core.Validation
{
   public static class Validation
    {
       /// <summary>
       /// Checks whether a wondercard is valid and reports accordingly
       /// </summary>
       /// <param name="wonderCardPath">The wonder card to check</param>
       /// <param name="SilentMode">If true, disables user error dialog boxes</param>
       /// <param name="DoByteCheck">Checks for the WORD value 'FFFF' at 0x0000027e->0x0000027f, a wondercard trait</param>
       /// <returns></returns>
       public static bool IsValidWondercard(string wonderCardPath,bool SilentMode,bool DoByteCheck)
       {
           if (!System.IO.File.Exists(wonderCardPath))
           {
               if (!SilentMode) ErrorDialogs.FileNotFoundBox(wonderCardPath, System.Windows.Forms.MessageBoxButtons.OK,
                    true);
               return false;
           }
           FileInfo fi = new FileInfo(wonderCardPath);
           if (fi.Length != 856)
           {
               if (SilentMode) return false;
               if (ErrorDialogs.WonderCardIsInvalid(wonderCardPath, System.Windows.Forms.MessageBoxButtons.YesNo, false, "Continue anyway, ignoring the file size mismatch?")
                   == System.Windows.Forms.DialogResult.Yes)
               {
               }
               else
               {
                   return false;
               }
           }
           if (DoByteCheck)
           {
               byte[] buffer = IO.Patcher.ReadDataFromFile(wonderCardPath, 0x0000027e, 2, 0);
               if (buffer[0] == 0xFF && buffer[1] == 0xFF)
               {
                   return true;
               }
               else
               {
                   if (SilentMode) return false;
                   if (ErrorDialogs.WonderCardIsInvalid(wonderCardPath, System.Windows.Forms.MessageBoxButtons.YesNo,
                       false, "忽略字节不一致，强制继续吗?") == System.Windows.Forms.DialogResult.No)
                   { return false; }
               }
           }
           return true;
       }

       public static bool IsValidNDSROM(string ndsPath, bool SilentMode, bool IndepthChecks, bool CRCCheck=false)
       {
           if (!System.IO.File.Exists(ndsPath))
           {
               if (!SilentMode) ErrorDialogs.FileNotFoundBox(ndsPath, System.Windows.Forms.MessageBoxButtons.OK,
                    true);
               return false;
           }
           if (IndepthChecks)
           {
               if (CRCCheck)
               {
                   return true; //todo, read the CRC correctly
                   bool result = DistroPatcher.NDSUtilities.IsCRCValid(ndsPath);
                   if (!result)
                   {
                       if (SilentMode) return false;
                       if (ErrorDialogs.NDSFileIsInvalid(ndsPath, System.Windows.Forms.MessageBoxButtons.YesNo,
                           false, "CRC错误检查失败，继续吗？") == System.Windows.Forms.DialogResult.Yes)
                       {
                           return true;
                       }
                       else return false;
                   }
               }
               //todo: implement nds file specification checks
           }
           return true;
       }
    }
}
