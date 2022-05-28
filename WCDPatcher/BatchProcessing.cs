using System.Collections.Generic;
using System.IO;
using WCDPatcher.Core.IO;

namespace WCDPatcher
{
    public static class BatchProcessing
    {
        /// <summary>
        /// Populates the macro list, with values from the specified file and wondercard
        /// </summary>
        /// <param name="filename">The distro to gather info from</param>
        /// <param name="wcard">The wondercard to gather info from</param>
        public static void PopulateMacroList(string filename, string wcard,ref Dictionary<string,string> macroList)
        {
            Dictionary<string, string> macros = macroList;

            FileStream FS = new FileStream(filename, FileMode.Open);

            char[] trl = { '\0' };

            string title = WCDPatcher.Core.NDSReaders.InternalFieldReader.GetNDSTitle(FS).Trim(trl);
            string lang = "英语";
            string desc = WCDPatcher.Core.NDSReaders.InternalFieldReader.GetNDSDescription(FS,WCDPatcher.Core.DistroPatcher.DistroOffsets.DescriptionOffsets.eng_desc).Trim(trl);
            string rtitle = WCDPatcher.Core.NDSReaders.InternalFieldReader.GetROMDescriptiveNameOrFirstLine(
                FS, WCDPatcher.Core.DistroPatcher.DistroOffsets.DescriptionOffsets.eng_desc);
            string rcomp = WCDPatcher.Core.NDSReaders.InternalFieldReader.GetNDSROMCompanyOrPublisherOrLastLine(FS,
            WCDPatcher.Core.DistroPatcher.DistroOffsets.DescriptionOffsets.eng_desc).Trim(trl);

            FileInfo FI = new FileInfo(wcard);
            int extLength = FI.Extension.Length;
            string wcn = FI.Name.Remove(FI.Name.Length - extLength, extLength);

            

            macros.Add("%t", title); macros.Add("%l", lang); macros.Add("%d", desc); macros.Add("%n", rtitle);
            macros.Add("%c", rcomp); macros.Add("%f", FI.Directory.Name); macros.Add("%w", wcn);

            FS.Dispose();

        }
        public static Dictionary<string, string> GetMacros(string ndsfile, string wcard)
        {
            Dictionary<string, string> macroStrOut = new Dictionary<string, string>();
            PopulateMacroList(ndsfile, wcard, ref macroStrOut);
            return macroStrOut;
        }
        public static string ConvertMacrosInString(string stringToAlter, Dictionary<string, string> macroList)
        {
            string final = stringToAlter;
            string[] keys = ArrayTools.GetKeyArray(macroList);
            for (int i = 0; i < keys.Length; i++)
            {
                string key = keys[i];
                string valout = macroList[key];
                final = stringToAlter.Replace(key, valout);
            }
            return final;
        }

        /// <summary>
        /// Loops through a collection of .pcds in a folder chosen by the user, and creates distros from them, using options from the main form
        /// </summary>
        /// <param name="Recursive">Search subfolders</param>
        /// <param name="Folder">The folder to search</param>
        /// <param name="options">The GUI form that holds the user chosen options</param>
        /// <returns>Success = true</returns>
        public static bool DoWonderCardFolder(bool Recursive, string Folder, GUI.GUI options)
        {
            if (!(System.IO.Directory.Exists(Folder))) return false;
            
            string dirToOutputTo = new FileInfo(options.txtNewRom.Text).Directory.FullName;
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = dirToOutputTo;

            string ALregion = options.cmbVersion.Text;
            string region = options.cmbLang.Text;

            string distroFile = options.txtDistro.Text;

            string desc = options.txtDesc.Text;
            string internN = options.txtInternal.Text;

            bool trimRom = options.chbTrim.Checked;

            int successFiles = 0;

            string[] files = System.IO.Directory.GetFiles(Folder, "*.pcd", (Recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly));

            int i = 0;
            for (i = 0; i < files.Length; i++)
            {
                if (!(new FileInfo(files[i]).Length == 856))
                {
                    continue;
                }
                Dictionary<string, string> macros = new Dictionary<string, string>();
                BatchProcessing.PopulateMacroList(options.txtDistro.Text, files[i], ref macros);
          

                string nDist = BatchProcessing.ConvertMacrosInString(options.txtNewRom.Text,macros);


                byte friendDist = System.Convert.ToByte(options.nudFriendDist.Value);
                bool mcOv = options.CheckMacroOverflow(true,macros); if (mcOv) continue;

                Core.DistroPatcher.DistroPatcher.PatchDistro(files[i], distroFile, nDist, BatchProcessing.ConvertMacrosInString(region,macros), ALregion,
                  BatchProcessing.ConvertMacrosInString(desc,macros), friendDist, (int)options.nudSeed.Value);

                successFiles++;
                string tmp = BatchProcessing.ConvertMacrosInString(options.txtNewRom.Text, macros);
                string ndstitle = BatchProcessing.ConvertMacrosInString(options.txtInternal.Text,macros);
                if (!(ndstitle == string.Empty))
                {

                    Core.DistroPatcher.NDSUtilities.SetNDSTitle(tmp, BatchProcessing.ConvertMacrosInString(
                        options.txtInternal.Text, macros), false);
                }

                Core.DistroPatcher.NDSUtilities.FixAllCRC(tmp);
                if (options.chbTrim.Checked) Core.DistroPatcher.NDSUtilities.trimRom(BatchProcessing.ConvertMacrosInString(options.txtNewRom.Text,macros));

            }

            System.Windows.Forms.MessageBox.Show("批处理操作完成\n" + successFiles.ToString() + "/" + i.ToString() + " 文件已成功打补丁"
                , "已完成", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button1);

            return true;
        }
    }
}
