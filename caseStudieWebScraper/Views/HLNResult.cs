using System;
using System.Collections.Generic;
using System.Text;
using caseStudieWebScraper.Models;

namespace caseStudieWebScraper.Views
{
    class HLNResult
    {
        public static void Print(IEnumerable<hln> Hln)
        {
            Console.Clear();
            Console.WriteLine("Resultaat.");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine();

            foreach (var artikel in Hln)
            {
                Console.WriteLine();
                Console.WriteLine("Naam = {0}", artikel.Naam);
                Console.WriteLine("Plaats = {0}", artikel.Plaats);
                Console.WriteLine("Beschrijving = {0}", artikel.Beschrijving);
                Console.WriteLine("link = {0}", artikel.ALink);
                Console.WriteLine();
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine();
            }

            Console.Write("Press enter to go back.");
        }
    }
}
