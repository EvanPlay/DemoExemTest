using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExemTest
{
    public class CryptoService
    {
        public static string CryptokeyText (string content, string key)
        {
            string s = key + content;
            return s;
        }

        public static string DeCryptokeyText(string contentCrypt, string key)
        {
            string s = key + contentCrypt.TrimStart(key.ToCharArray());
            return s;
        }
    }
}
