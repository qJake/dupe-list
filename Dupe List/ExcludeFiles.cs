using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DupeList
{
    public static class ExcludeFiles
    {
        static string[] EXCLUDE_FILES = new string[]
        {
            "desktop.ini",
            "thumbs.db"
        };

        public static bool IsExcludedFile(string file)
        {
            foreach (string ex in EXCLUDE_FILES)
            {
                if (ex == file) return true;
            }
            return false;
        }
    }
}
