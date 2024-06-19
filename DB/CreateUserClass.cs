using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExemTest.DB
{
    //Класс создания юзера
    public class CreateUserClass
    {
        public static void CreateUser(string username, string password, string defDb, string cs)
        {
            SqlConnection sqlConnection = new SqlConnection(cs);

            var str =
                $"CREATE LOGIN [{username}] WITH PASSWORD=N'{password}'," +
                $"DEFAULT_DATABASE=[{defDb}] , " +
                $"CHECK_EXPIRATION=OFF, " +
                $"CHECK_POLICY=OFF " +
                $"USE[{defDb}]  " +
                $"CREATE USER[{username}]  FOR LOGIN[{username}]  " +
                $"USE [{defDb}] " +
                $"ALTER ROLE[db_owner] ADD MEMBER [{username}]  ";

            SqlCommand sqlCommand = new SqlCommand(str, sqlConnection);

            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }
    }
}
