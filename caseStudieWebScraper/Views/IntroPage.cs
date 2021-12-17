using System;

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
            Console.WriteLine("Type A voor youtube scraper.");
            Console.WriteLine("Type E voor youtube scraper results.");
            Console.WriteLine("Type I voor verwijderen van youtube scraper results.");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Type B voor indeed scraper");
            Console.WriteLine("Type F voor indeed scraper results");
            Console.WriteLine("Type J voor verwijderen van indeed scraper results");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Type C voor Het Laatste Nieuws scraper");
            Console.WriteLine("Type G voor Het Laatste Nieuws scraper results");
            Console.WriteLine("Type K voor verwijderen van Het Laatste Nieuws scraper results");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine();
            Console.Write("Enter keuze: ");
        }
    }
}
