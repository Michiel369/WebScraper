using Dapper;
using Microsoft.Data.Sqlite;
using System.IO;

namespace caseStudieWebScraper.DAL
{
    class SqlLiteBase
    {
        public SqlLiteBase()
        {
        }

        public static SqliteConnection DataBankConnectionMaken()
        {
            return new SqliteConnection(@"DataSource=ScraperDB.sqlite");
        }

        protected static bool DatabaseExists()
        {
            return File.Exists(@"ScraperDB.sqlite");
        }

        protected static void CreateDatabank()
        {
            using (var connectie = DataBankConnectionMaken())
            {
                connectie.Open();
                
                connectie.Execute(
                    @"CREATE TABLE YT
                    (
                    Id              INTEGER PRIMARY KEY AUTOINCREMENT,
                    Title           VARCHAR(100),
                    Uploader        VARCHAR(100),
                    View           VARCHAR(100),
                    Link            VARCHAR
                    )");
                
                connectie.Execute(
                    @"CREATE TABLE HLN
                    (
                    Id              INTEGER PRIMARY KEY AUTOINCREMENT,
                    Naam            VARCHAR(100),
                    Plaats          VARCHAR(100),
                    Beschrijving    VARCHAR(100),
                    ALink           VARCHAR
                    )");
                
                connectie.Execute(
                    @"CREATE TABLE indeed
                    (
                    Id              INTEGER PRIMARY KEY AUTOINCREMENT,
                    JobTitle        VARCHAR(100),
                    Company         VARCHAR(100),
                    Location        VARCHAR(100),
                    Href            VARCHAR
                    )");
            }
        }
    }
}
