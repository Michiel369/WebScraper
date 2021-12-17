using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using caseStudieWebScraper.DAL;
using caseStudieWebScraper.Models;

namespace caseStudieWebScraper.Views
{
    class youtubeResult
    {
        public static void Print(IEnumerable<YT> YTVideos)
        {
            Console.Clear();
            Console.WriteLine("Resultaat.");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine();

            foreach (var video in YTVideos)
            {
                Console.WriteLine();
                Console.WriteLine("Titel = {0}", video.Title);
                Console.WriteLine("uploader = {0}", video.Uploader);
                Console.WriteLine("views = {0}", video.View);
                Console.WriteLine("link = {0}", video.Link);
                Console.WriteLine();
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine();
            }

            Console.Write("Press enter to go back.");
        }
    }
}
