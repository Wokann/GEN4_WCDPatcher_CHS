
namespace WCDPatcher.Core.IO
{
    public static class StringTools
    {   /// <summary>
        /// Removes invalid path characters
        /// </summary>
        /// <param name="Filename">The path to remove invalid chars from</param>
        public static void RemoveInvalidFileSystemChars(ref string Filepath)
        {
            System.Collections.ArrayList AL = new System.Collections.ArrayList(System.IO.Path.GetInvalidPathChars());

            for (int i = 0; i < Filepath.Length; i++)
            {
                if (AL.Contains(Filepath[i]))
                {
                    char c = Filepath[i];
                    Filepath = Filepath.Replace(c, ' ');
                }
            }
        }
    }
}
