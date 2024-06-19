using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExemTest.DB
{
    //Класс восстановления базы данных
    public class BackUpDataBaseClass
    {
        public static string BackUpDataBase(string db_name, string cs, string dir)
        {
            SqlConnection sqlConnection = new SqlConnection(cs);
            var data = DateTime.Now;
            var dataInfo = $"{db_name}-{data.Year}_{data.Month}_{data.Day}_{data.Hour}_{data.Minute}_{data.Second}.bac";

            var str =
                $"BACKUP DATABASE [{db_name}]" +
                @$"TO DISK = N'{dir}\{dataInfo}' WITH NOFORMAT, NOINIT, " +
                $"NAME = N'{dataInfo}', " +
                $"SKIP, NOREWIND, NOUNLOAD, STATS = 10";

            SqlCommand sqlCommand = new SqlCommand(str, sqlConnection);
            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                return $@"Create {dataInfo} in {dir} directory";
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
