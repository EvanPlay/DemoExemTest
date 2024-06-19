using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DemoExemTest.DB
{
    //Класс подключения программы к серверу и базе данных
    public class MyConect : DbContext
    {
        private string ConnectionString =
            "server=;database=;user=;password;";//Добавить инфомрацию о сервере

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
        public DbSet<User> Users { get; set; }
    }
}
