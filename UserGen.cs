using DemoExemTest.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExemTest
{
    //Класс создания пользователей
    public class UserGen
    {
        public static List<string> Add(string? pref, string prefDb, int count, int lenghtPass, string cs)
        {
            try
            {
                List<string> list = new List<string>();
                for (int i = 1; i <= count; i++)
                {
                    string us = pref + i;
                    string pass = PasswordGen.GetPass(lenghtPass);
                    string db = prefDb + i;

                    CreateDataBaseClass.CreateDataBase(db, cs);
                    CreateUserClass.CreateUser(us, db, pass, cs);
                    list.Add($"User:{us}; DataBase:{db}; Password:{pass}");
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
