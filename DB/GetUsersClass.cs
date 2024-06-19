using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExemTest.DB
{
    public class GetUsersClass
    {
        //Класс формирования списка пользователей
        public static List<User> GetUsers(string db_name, string cs)
        {
            List<User> users = new List<User>();
            SqlConnection sqlConnection = new SqlConnection(cs);
            var str =
                $@"SELECT TOP (1000) [UserId],[Name],[Login],[Password] FROM [{db_name}].[dbo].[User]";
            SqlCommand sqlCommand = new SqlCommand(str, sqlConnection);
            try
            {
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader != null)
                {
                    while (sqlDataReader.Read())
                    {
                        User user = new User();
                        user.Name = sqlDataReader.GetValue(1).ToString();
                        user.Login = sqlDataReader.GetValue(2).ToString();
                        user.pasforDB = sqlDataReader.GetValue(3).ToString();
                        users.Add(user);
                    }
                }
                return users;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
