using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


using Microsoft.Extensions.Configuration;

using System.IO;

//using Microsoft.EntityFrameworkCore; https://coderoad.ru/38557170/%D0%9F%D1%80%D0%BE%D1%81%D1%82%D0%BE%D0%B9-%D0%BF%D1%80%D0%B8%D0%BC%D0%B5%D1%80-%D0%B8%D1%81%D0%BF%D0%BE%D0%BB%D1%8C%D0%B7%D0%BE%D0%B2%D0%B0%D0%BD%D0%B8%D1%8F-System-Data-SQLite-%D1%81-Entity-Framework-6


namespace ProjectNavigator
{
    public class ApplicationContext : DbContext
    {
        //public ApplicationContext() : base(new SQLiteConnectionStringBuilder() { DataSource = "u:\\dev\\ProjectNavigator\\ProjectNavigator\\ProjectNavigator\\prbr01.db", ForeignKeys = true }.ConnectionString)
        //{
        //}

        public DbSet<Dev> Devs { get; set; }
        public DbSet<Block> Blocks { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Pack> Packs { get; set; }

        //protected override void OnConfiguring(ApplicationContext optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Filename=Mobile.db");
        //}

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
                    : base(options)
        {
            Database.EnsureCreated();
        }
    }

    public static class DbSQLiteBuilder
    {
        public static DbContextOptions<ApplicationContext> GetSQLiteConnectOptions()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var builder = new ConfigurationBuilder();

            // установка пути к текущему каталогу
            builder.SetBasePath(Directory.GetCurrentDirectory());
            // получаем конфигурацию из файла appsettings.json
            builder.AddJsonFile("appsettings.json");
            // создаем конфигурацию
            var config = builder.Build();
            // получаем строку подключения
            string connectionString = config.GetConnectionString("DefaultConnection");

            var options = optionsBuilder
                .UseSqlite(connectionString)
                .Options;

            return options;

        }

        /*
         * 
         * var builder = new ConfigurationBuilder();
        // установка пути к текущему каталогу
        builder.SetBasePath(Directory.GetCurrentDirectory());
        // получаем конфигурацию из файла appsettings.json
        builder.AddJsonFile("appsettings.json");
        // создаем конфигурацию
        var config = builder.Build();
        // получаем строку подключения
        string connectionString = config.GetConnectionString("DefaultConnection");

        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
        var options = optionsBuilder
            .UseSqlServer(connectionString)
            .Options;
        */

    }


}
