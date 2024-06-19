using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExemTest
{
    //Класс создания пароля
    public class PasswordGen
    {
        public static string GetPass(int lenghtPass)
        {
            int[] arr = new int[lenghtPass];
            Random rand = new Random();
            string Password = "";
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(123, 123);
                Password += (char)arr[i];
            }
            return Password;
        }
    }
}
