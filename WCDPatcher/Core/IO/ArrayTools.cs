using System.Collections.Generic;

namespace WCDPatcher.Core.IO
{
    public static class ArrayTools
    {
        public static string GetKeyAtIndex(int Index, Dictionary<string, byte[]> list)
        {
            if (list == null) return "";

            IEnumerator<string> ie = list.Keys.GetEnumerator();

            for (int i = 0; i < Index; i++)
            {
                bool mvOK = ie.MoveNext();
                if (mvOK == false) return "";
            }
            return ie.Current;
        }

        public static string[] GetKeyArray(Dictionary<string, byte[]> list)
        {
            if (list == null) return null;

            int max = list.Keys.Count;
            IEnumerator<string> ie = list.Keys.GetEnumerator();
            string[] final = new string[max];

            ie.MoveNext();
            for (int i = 0; i < max; i++)
            {
                final[i] = ie.Current;
                ie.MoveNext();
            }

            return final;
        }
        public static string[] GetKeyArray(Dictionary<string, string> list)
        {
            if (list == null) return null;

            int max = list.Keys.Count;
            IEnumerator<string> ie = list.Keys.GetEnumerator();
            string[] final = new string[max];

            ie.MoveNext();
            for (int i = 0; i < max; i++)
            {
                final[i] = ie.Current;
                ie.MoveNext();
            }

            return final;
        }

    }
}
