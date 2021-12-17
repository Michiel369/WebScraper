using caseStudieWebScraper.Models;
using System;
using System.Collections.Generic;

namespace caseStudieWebScraper.Views
{
    class RemoveIndeed
    {
        public static void Print(IEnumerable<InD> InDeed)
        {
            Console.Clear();
            Console.WriteLine("Indeed scraper resultaat");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine();

            foreach (var vac in InDeed)
            {
                Console.WriteLine();
                Console.WriteLine("Job titel = {0}", vac.JobTitle);
                Console.WriteLine("Bedrijf = {0}", vac.Company);
                Console.WriteLine("Locatie = {0}", vac.Location);
                Console.WriteLine("link = {0}", vac.Href);
                Console.WriteLine();
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine();
            }

            Console.Write("Enter job titel: ");
        }
    }
}
