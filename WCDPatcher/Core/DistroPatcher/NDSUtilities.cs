using System;
using WCDPatcher.Core.IO;
using System.IO;

namespace WCDPatcher.Core.DistroPatcher
{
    public static class NDSUtilities
    {
        /// <summary>
        /// Sets an NDS's title
        /// </summary>
        /// <param name="distroFile">The distro to modify</param>
        /// <param name="Title">The new name</param>
        public static void SetNDSTitle(string distroFile, string Title,bool FixCRC)
        {
            if (Title.Length > 12 || Title.Length == 0 || Title == "") return;

            byte[] newTitle = System.Text.ASCIIEncoding.ASCII.GetBytes(Title);
            byte[] nds = Patcher.GetFileBytes(distroFile);

            if (newTitle.Length != 12)
            {
                byte[] tmp = new byte[newTitle.Length];
                newTitle.CopyTo(tmp, 0);
                newTitle = new byte[12];
                tmp.CopyTo(newTitle, 0);
                tmp = null;

            }

            Patcher.WriteDataInBuffer(nds, newTitle, 0x00);

            Patcher.WriteBufferToFile(distroFile, nds);

            if (FixCRC) { FixAllCRC(distroFile); }
        }

        /// <summary>
        /// Fixes the header crc16 after edits
        /// </summary>
        /// <param name="Filename">The file to fix</param>
        public static void FixAllCRC(string Filename)
        {

            //The crc's need to be written in the order of secure area, logo and header, as the DS performs the CRC in this order

            if (!System.IO.File.Exists(Filename)) return;

            FileStream FS = new FileStream(Filename, FileMode.Open);

            byte[] HeaderFill = new byte[350];
            byte[] bannerFill = new byte[2080];

            

            FS.Seek(0, SeekOrigin.Begin);
            FS.Read(HeaderFill, 0, 350);

            FS.Seek(DistroOffsets.CRC_Offsets.BannerCRCOffset + 30, 0);
            FS.Read(bannerFill, 0, 2080);

            DSCRCTool crc = new WCDPatcher.Core.IO.DSCRCTool();

            crc.InitCRC16();

            byte[] headerCRC = BitConverter.GetBytes(crc.crcbitbybit(HeaderFill));
            byte[] bannerCRC = BitConverter.GetBytes(crc.crcbitbybit(bannerFill));

            FS.Seek(DistroOffsets.CRC_Offsets.HeaderCRCOffset, SeekOrigin.Begin);
            FS.Write(headerCRC, 0, 2);

            FS.Seek(DistroOffsets.CRC_Offsets.BannerCRCOffset, SeekOrigin.Begin);
            FS.Write(bannerCRC, 0, 2);

            FS.Close();
        }

     

        public static bool IsCRCValid(string ndsFile)
        {
            if (!System.IO.File.Exists(ndsFile)) return false;

            FileStream FS = new FileStream(ndsFile, FileMode.Open);

            byte[] HeaderFill = new byte[350];
            byte[] read_HeaderCRC;
            read_HeaderCRC = new byte[2];

            FS.Seek(0, SeekOrigin.Begin);
            FS.Read(HeaderFill, 0, 350);

            DSCRCTool crc = new WCDPatcher.Core.IO.DSCRCTool();

            crc.InitCRC16();

            byte[] headerCRC = BitConverter.GetBytes(crc.crcbitbybit(HeaderFill));


            FS.Seek(DistroOffsets.CRC_Offsets.HeaderCRCOffset, SeekOrigin.Begin);
            FS.Read(read_HeaderCRC, 0, 2);

            bool header = ByteTools.IsByteArrayEqual(read_HeaderCRC, headerCRC);
  
            if (header)
            {
                FS.Close();
                return true;
            }
            

            FS.Close();
            return false;
        }

        /// <summary>
        /// Trims a NDS ROM
        /// </summary>
        /// <param name="ROM">The NDS file to trim</param>
        public static void trimRom(string ROM)
        {
            StringTools.RemoveInvalidFileSystemChars(ref ROM);

            int num;
            BinaryReader reader = new BinaryReader(File.Open(ROM, FileMode.Open));
            byte[] buffer = new byte[4];
            byte[] buffer2 = new byte[0x84];
            reader.Read(buffer2, 0, 0x84);
            for (num = 0; num < 4; num++)
            {
                buffer[num] = buffer2[0x80 + num];
            }
            long[] numArray = new long[4];
            for (num = 0; num < 4; num++)
            {
                numArray[num] = buffer[num];
                if (numArray[num] < 0L)
                {
                    numArray[num] = 0x100L + numArray[num];
                }
            }
            reader.Close();
            long num2 = (((numArray[0] + (numArray[1] * 0x100L)) + ((numArray[2] * 0x100L) * 0x100L)) + (((numArray[3] * 0x100L) * 0x100L) * 0x100L)) + 0x88L;
            FileStream stream = new FileStream(ROM, FileMode.Open);
            FileStream stream2 = new FileStream(ROM.Substring(0, ROM.Length - 4) + "_.nds", FileMode.Create);
            byte[] buffer3 = new byte[num2];
            stream.Read(buffer3, 0, (int)num2);
            stream2.Write(buffer3, 0, (int)num2);
            stream.Close();
            stream2.Close();

            //Added code
            {
                if (System.IO.File.Exists(ROM)) System.IO.File.Delete(ROM);
                System.IO.File.Move(ROM.Substring(0, ROM.Length - 4) + "_.nds", ROM);
            }
            //end
        }
    }
}
