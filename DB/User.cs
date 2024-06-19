using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExemTest.DB
{
    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
        internal string pasforDB { get; set; }

        private string SetPass(string vaule)
        {
            return CryptoService.CryptokeyText(vaule, "123");
        }
        private string GetPass(string vaule)
        {
            return CryptoService.DeCryptokeyText(vaule, "123");
        }
        public override string ToString()
        {
            return $"Name:{Name}, Login:{Login}, Password:{Password}";
        }
    }
}
