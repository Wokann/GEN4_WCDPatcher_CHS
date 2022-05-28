using System.IO;

namespace WCDPatcher.Core.IO
{    /// <summary>
    /// A class used to assist in patching operations
    /// </summary>
    public class Patcher
    {
        /// <summary>
        /// Retrieve all bytes from a file
        /// </summary>
        /// <param name="File">The file to retrieve data from</param>
        /// <returns>Null if file does not exist, or could not be read</returns>
        public static byte[] GetFileBytes(string File)
        {
            if (!System.IO.File.Exists(File)) { return null; }

            byte[] buffer = System.IO.File.ReadAllBytes(File);

            return buffer;
        }

        /// <summary>
        /// Writes data into a buffer
        /// </summary>
        /// <param name="buffer">The buffer to write to</param>
        /// <param name="Data">The data to write</param>
        /// <param name="offset">The offset to begin writing</param>
        public static void WriteDataInBuffer(byte[] buffer, byte[] Data, long offset)
        {
            MemoryStream MS = new MemoryStream(buffer);
            MS.Seek(offset, SeekOrigin.Begin);

            MS.Write(Data, 0, Data.Length);
            MS.Flush();
            MS.Dispose();
        }

        /// <summary>
        /// Gets a buffer of data, from the specifed file and address range
        /// </summary>
        /// <param name="originArray">The byte array to read from</param>
        /// <param name="offset">The offset to read from</param>
        /// <param name="length">The number of bytes to read</param>
        /// <returns></returns>
        public static byte[] ReadDataFromArray(byte[] originArray, long offset, long length)
        {
            byte[] retbuf = new byte[length];
            MemoryStream MS = new MemoryStream(originArray);

            MS.Seek(offset, SeekOrigin.Begin);
            MS.Read(retbuf, 0, (int)length);
            MS.Close();
            MS.Dispose();

            return retbuf;
        }

        /// <summary>
        /// Writes the content of a byte array to a file
        /// </summary>
        /// <param name="Filename">The file to write to</param>
        /// <param name="buffer">The data to write</param>
        public static void WriteBufferToFile(string Filename, byte[] buffer)
        {
            string dir = Path.GetDirectoryName(Filename);
            if (!System.IO.Directory.Exists(dir)) System.IO.Directory.CreateDirectory(dir);
            StringTools.RemoveInvalidFileSystemChars(ref Filename);
            System.IO.File.WriteAllBytes(Filename, buffer);

        }

        public static byte[] ReadDataFromFile(string filename, long offset, long length, long origin=0)
        {
            if (!System.IO.File.Exists(filename)) return null;
            byte[] buffer = new byte[length];
            FileStream fs = new FileStream(filename, System.IO.FileMode.Open);
            fs.Seek(origin + offset, SeekOrigin.Begin);
            fs.Read(buffer, 0, (int)length);
            fs.Close();
            fs = null;
            return buffer;
        }

        /// <summary>
        /// Reads a byte from the interval specifed, until the max interval or max length is reached
        /// </summary>
        /// <param name="buffer">The buffer to read from</param>
        /// <param name="interval">The interval at which to read a byte from</param>
        /// <param name="offset">The offset to begin at</param>
        /// <param name="maxlength">The maximum length of the buffer to read from</param>
        /// <param name="maxintervals">The maximum amount of intervals</param>
        /// <returns></returns>
        public static byte[] ReadIntervalBytes(byte[] buffer, int interval, int offset, int maxlength, int maxintervals)
        {
            byte[] conta = { };

            for (int i = offset; i < maxintervals; i++)
            {
                if (i >= (buffer.Length / maxintervals)) break;
                if (i >= maxlength) break;
                System.Array.Resize(ref conta, conta.Length + 1);
                conta[conta.Length - 1] = buffer[i];
                i += interval;
            }

            return conta;
        }

        #region shortcutVoids
        private static bool de(string d)
        {
            return Directory.Exists(d);
        }
        private static bool fe(string f)
        {
            return System.IO.File.Exists(f);
        }
        #endregion
    }
}

