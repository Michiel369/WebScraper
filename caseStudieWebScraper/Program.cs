using System;
using caseStudieWebScraper.Views;
using caseStudieWebScraper.Models;
using caseStudieWebScraper.scrapers;
using System.Collections.Generic;
using caseStudieWebScraper.DAL;

namespace caseStudieWebScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            YoutubeRepository youtubeRepository = new YoutubeRepository();

            HashSet<YT> YTVideos = new HashSet<YT>(youtubeRepository.GetVideos());
            HashSet<InD> InDeed = new HashSet<InD>(youtubeRepository.GetVac());
            HashSet<hln> Hln = new HashSet<hln>(youtubeRepository.GetArtikels());
            do
            {
                IntroPage.Print();
                string keuze = Console.ReadLine().Substring(0, 1).ToUpper();

                if (keuze == "A")
                {
                    youtube.Print();
                    string zoekWoord = Console.ReadLine();
                    youtubeScraper.Scrape(zoekWoord, YTVideos, youtubeRepository);
                    youtubeResult.Print(YTVideos);
                    Console.ReadLine();
                }
                else if (keuze == "E")
                {
                    youtubeResult.Print(YTVideos);
                    Console.ReadLine();
                }
                else if (keuze == "I")
                {
                    RemoveYT.Print(YTVideos);
                    string RTitel = Console.ReadLine();
                    YTVideos.RemoveWhere(x => x.Title == RTitel);
                    youtubeRepository.DeleteYT(RTitel);
                }


                else if (keuze == "B")
                {
                    indeed.Print();
                    string what = Console.ReadLine();
                    IndeedScraper.Scrape(what, InDeed, youtubeRepository);
                    indeedResult.Print(InDeed);
                    Console.ReadLine();
                }
                else if (keuze == "F")
                {
                    indeedResult.Print(InDeed);
                    Console.ReadLine();
                }
                else if (keuze == "J")
                {
                    RemoveIndeed.Print(InDeed);
                    string Rindeed = Console.ReadLine();
                    InDeed.RemoveWhere(x => x.JobTitle == Rindeed);
                    youtubeRepository.DeleteIndeed(Rindeed);
                }


                else if (keuze == "C")
                {
                    HLN.Print();
                    string zoekTerm = Console.ReadLine();
                    HLNScraper.Scrape(zoekTerm, Hln, youtubeRepository);
                    HLNResult.Print(Hln);
                    Console.ReadLine();
                }
                else if (keuze == "G")
                {
                    HLNResult.Print(Hln);
                    Console.ReadLine();
                }
                else if (keuze == "K")
                {
                    RemoveHLN.Print(Hln);
                    string Rhln = Console.ReadLine();
                    Hln.RemoveWhere(x => x.Naam == Rhln);
                    youtubeRepository.DeleteHln(Rhln);
                }


                else
                {
                    youtube.Print();
                }

            } while (true);
        }
    }
}
