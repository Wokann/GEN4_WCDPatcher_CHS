using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace WCDPatcher.Core.NDSReaders
{
    public static class InternalFieldReader
    {
        /// <summary>
        /// Gets the internal rom title from the distro
        /// </summary>
        /// <param name="fs">The file stream to read from</param>
        /// <returns></returns>
        public static string GetNDSTitle(FileStream fs)
        {
            byte[] tmp = new byte[12];

            fs.Seek(0, SeekOrigin.Begin);
            fs.Read(tmp, 0, 12);

            return ASCIIEncoding.ASCII.GetString(tmp);
        }



        /// <summary>
        /// Gets the rom description from a distro
        /// </summary>
        /// <param name="fs">the file stream to read from</param>
        /// <param name="languageOffset">The language to read from. Get language offsets from DistroPatcher.DistroOffsets.DescriptionOffsets</param>
        /// <returns></returns>
        public static string GetNDSDescription(FileStream fs,int languageOffset)
        {
            byte[] tmp = new byte[256];
            byte[] fin = new byte[128];

            fs.Seek(DistroPatcher.DistroOffsets.DescriptionOffsets.eng_desc, SeekOrigin.Begin);
            fs.Read(tmp, 0, 256);

            for (int i = 0; i < 256 - 1; i++)
            {
                if (tmp[i] == 0x00) continue;

                fin[i] = tmp[i];
            }
            return UTF8Encoding.UTF8.GetString(fin);
        }

        /// <summary>
        /// Reads the whole ROM description block, and then returns the first line, usually the ROM name
        /// </summary>
        /// <param name="FS">the file stream to read from</param>
        /// <param name="languageOffset">The language to read from. Get language offsets from DistroPatcher.DistroOffsets.DescriptionOffsets</param>
        /// <returns>If the description is multiline, returns the first line. If not a multline description, returns the entire description</returns>
        public static string GetROMDescriptiveNameOrFirstLine(FileStream FS,int languageOffset)
        {
            string fulls = GetNDSDescription(FS,languageOffset);
            if (!fulls.Contains("\n")) return fulls;

            string[] splits = fulls.Split(new char[] { '\n' });

            return splits[0];
        }

        /// <summary>
        /// Gets the company of the distro
        /// </summary>
        /// <param name="languageOffset">The language to read from. Get language offsets from DistroPatcher.DistroOffsets.DescriptionOffsets</param>
        /// <param name="FS">The file stream to read from</param>
        /// <returns>If the description is multiline, returns the last line. If not a multline description, returns the entire description</returns>
        public static string GetNDSROMCompanyOrPublisherOrLastLine(FileStream FS,int languageOffset)
        {
            string fulls = GetNDSDescription(FS, languageOffset);
            if (!fulls.Contains("\n")) return fulls;

            string[] splits = fulls.Split(new char[] { '\n' });

            return splits[splits.Length - 1];
        }
    }
}
