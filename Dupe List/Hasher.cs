using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace DupeList
{
    public static class Hasher
    {
        static MD5 md = MD5.Create();

        public static string md5(byte[] contents)
        {
            return bytesToHex(md.ComputeHash(contents));
        }

        private static string bytesToHex(byte[] bytes)
        {
            string ret = "";
            foreach (byte b in bytes)
            {
                ret += b.ToString("x2").ToLower();
            }
            return ret;
        }
    }
}
