using System.IO;
using System.Security.Cryptography;
using System.Text;
namespace WCDPatcher.Core.IO
{
    public static class ByteTools
    {
        public static char[] ValidHexChars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

        /// <summary>
        /// Gets a file's MD5 hash
        /// </summary>
        /// <param name="ROM"></param>
        /// <returns></returns>
        public static string GetFileMD5Hash(string Filename)
        { //kudos to MSDN
            if (System.IO.File.Exists(Filename))
            {
                StringBuilder sb = new StringBuilder();
                FileStream fs = new FileStream(Filename, FileMode.Open);
                byte[] buffer = new MD5CryptoServiceProvider()
                    .ComputeHash(fs);
                fs.Close();
                foreach (byte num in buffer)
                {
                    sb.Append(num.ToString("x2"));
                }
                return sb.ToString().ToUpper();
            }
            else return null;
        }

        public static bool CompareHashes(string FileToHash, string HashToCompareTo)
        {
            if (!System.IO.File.Exists(FileToHash)) return false;
            string hash = GetFileMD5Hash(FileToHash);
            return (hash == HashToCompareTo);
        }

        /// <summary>
        /// Checks if two byte arrays are equal.
        /// </summary>
        /// <param name="arrayOne">The first array to check</param>
        /// <param name="arrayTwo">The second array to check against</param>
        /// <returns></returns>
        public static bool IsByteArrayEqual(byte[] arrayOne, byte[] arrayTwo)
        { /*This method works by checking each byte in a loop to see if the same byte
            at the same position in array two
           if it is different, return a false. if it all checks out, return true*/
            if (arrayOne == null || arrayTwo == null) return false;

            if (arrayOne.Length != arrayTwo.Length) return false;

            int countMax = (arrayOne.Length + arrayTwo.Length) / 2;

            for (int i = 0; i < countMax; i++)
            {
                if (!(arrayOne[i] == arrayTwo[i])) return false;
            }
            return true;

        }

        /// <summary>
        ///  convert the byte array back to a true string
        /// </summary>
        /// <param name="bytes_Input">The bytes to convert</param>
        /// <returns></returns>
        public static string ConvertBytesToString(byte[] bytes_Input)
        {
            StringBuilder strTemp = new StringBuilder(bytes_Input.Length * 2);
            foreach (byte b in bytes_Input)
            {
                strTemp.Append(b.ToString("X02"));
            }
            return strTemp.ToString();
        }
          /// <summary>
        /// Returns true if a string is a valid set of 4 hec values, able to be converted e.g. 801D
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static bool IsValidFourWORDHexString(string hex)
        {
            if (hex.Length == 4)
            {
                System.Collections.ArrayList al = new System.Collections.ArrayList(ValidHexChars);

                if (al.Contains(hex[0]) && al.Contains(hex[1]) && al.Contains(hex[2]) && al.Contains(hex[3]))
                {
                  
                    return true;

                }
                else return false;
            }
            else return false;
        }
        /// <summary>
        /// Converts a hex string to bytes
        /// </summary>
        /// <param name="strInput">The string to convert</param>
        /// <returns></returns>
        public static byte[] ConvertHexStringToBytes(string strInput)
        {
            // allocate byte array based on half of string length
            int numBytes = (strInput.Length) / 2;
            byte[] bytes = new byte[numBytes];

            // loop through the string - 2 bytes at a time converting it to decimal equivalent and store in byte array
            // x variable used to hold byte array element position
            for (int x = 0; x < numBytes; ++x)
            {
                bytes[x] = System.Convert.ToByte(strInput.Substring(x * 2, 2), 16);
            }

            // return the finished byte array of decimal values
            return bytes;
        }
    }
}
