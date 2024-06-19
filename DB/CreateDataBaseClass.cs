using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExemTest.DB
{
    //Класс создания базы данных
    public class CreateDataBaseClass
    {
        public static void CreateDataBase(string db_name, string cs)
        {
            SqlConnection sqlConnection = new SqlConnection(cs);
            var str = $"CREATE DATABASE {db_name}";
            SqlCommand sqlCommand = new SqlCommand(str, sqlConnection);
            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }
    }
}
