using System.Collections.Generic;
using Dapper;
using caseStudieWebScraper.Models;

namespace caseStudieWebScraper.DAL
{
    class YoutubeRepository : SqlLiteBase
    {
        public YoutubeRepository()
        {

            if (!DatabaseExists())
            {
                CreateDatabank();
            }
            
        }

        public int InsertYT(YT YTVideos)
        {
            string sql = "INSERT INTO YT (Title, Uploader, View, Link) Values (@Title, @Uploader, @View, @Link);";

            using (var connection = DataBankConnectionMaken())
            {
                connection.Open();
                return connection.Execute(sql, YTVideos);
            }
        }
        public int DeleteYT(string RTitel)
        {
            string sql = "DELETE FROM YT WHERE Title = @Title;";

            using (var connectie = DataBankConnectionMaken())
            {
                connectie.Open();
                return connectie.Execute(sql, new { Title = RTitel } );
            }
        }
        public IEnumerable<YT> GetVideos()
        {
            string sql = "SELECT * FROM YT;";

            using (var connection = DataBankConnectionMaken())
            {
                return connection.Query<YT>(sql);
            }
        }



        public int InsertHLN(hln HLN)
        {
            string sql = "INSERT INTO HLN (Naam, Plaats, Beschrijving, ALink) Values (@Naam, @Plaats, @Beschrijving, @ALink);";

            using (var connection = DataBankConnectionMaken())
            {
                connection.Open();
                return connection.Execute(sql, HLN);
            }
        }
        public int DeleteHln(string Rhln)
        {
            string sql = "DELETE FROM HLN WHERE Naam = @Naam;";

            using (var connectie = DataBankConnectionMaken())
            {
                connectie.Open();
                return connectie.Execute(sql, new { Naam = Rhln });
            }
        }
        public IEnumerable<hln> GetArtikels()
        {
            string sql = "SELECT * FROM HLN;";

            using (var connection = DataBankConnectionMaken())
            {
                return connection.Query<hln>(sql);
            }
        }



        public int InsertIndeed(InD InD)
        {
            string sql = "INSERT INTO indeed (JobTitle, Company, Location, Href) Values (@JobTitle, @Company, @Location, @Href);";

            using (var connection = DataBankConnectionMaken())
            {
                connection.Open();
                return connection.Execute(sql, InD);
            }
        }
        public int DeleteIndeed(string Rindeed)
        {
            string sql = "DELETE FROM indeed WHERE JobTitle = @JobTitle;";

            using (var connectie = DataBankConnectionMaken())
            {
                connectie.Open();
                return connectie.Execute(sql, new { JobTitle = Rindeed });
            }
        }
        public IEnumerable<InD> GetVac()
        {
            string sql = "SELECT * FROM indeed;";

            using (var connection = DataBankConnectionMaken())
            {
                return connection.Query<InD>(sql);
            }
        }
    }
}
