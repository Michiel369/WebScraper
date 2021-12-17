using System;
using System.Collections.Generic;
using System.Text;

namespace caseStudieWebScraper.Views
{
    static class IntroPage
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("WebScraper");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Type A for youtube scraper.");
            Console.WriteLine("Type E for youtube scraper results.");
            Console.WriteLine("Type I for removing youtube scraper results.");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Type B for indeed scraper");
            Console.WriteLine("Type F for indeed scraper results");
            Console.WriteLine("Type J for removing indeed scraper results");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Type C for Het Laatste Nieuws scraper");
            Console.WriteLine("Type G for Het Laatste Nieuws scraper results");
            Console.WriteLine("Type K for removing Het Laatste Nieuws scraper results");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine();
            Console.Write("Enter keuze: ");
        }
    }
}
