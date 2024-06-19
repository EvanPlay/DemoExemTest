using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExemTest.DB
{
    //Класс создания таблицы пользователей
    public class CreateTableUsersClass
    {
        public static void CreateTableUsers(string db_name, string cs)
        {
            SqlConnection sqlConnection = new SqlConnection(cs);
            var str =
                $"USE {db_name}\n " +
                $"CREATE TABLE [dbo].[User] " +
                $"(UserId int Identity(1,1), " +
                $"Name nvachar(50) not null " +
                $"Login nvachar(50) not null " +
                $"Password nvachar(50) not null) ";

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
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }
    }
}
