using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using caseStudieWebScraper.Models;
using caseStudieWebScraper.DAL;

namespace caseStudieWebScraper.scrapers
{
    class IndeedScraper
    {
        private static IWebDriver driver;
        public static void Scrape(string what, HashSet<InD> InDeed, YoutubeRepository youtubeRepository)
        {
            string wat = what;
            string waar = "België";
            int aantalJobs = 0;

            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://be.indeed.com/");
            Thread.Sleep(200);

            // vul job title, company or keywords in
            var w = driver.FindElement(By.Id("text-input-what"));
            w.SendKeys(wat);
            Thread.Sleep(200);

            // vul city, province or postal code in
            var where = driver.FindElement(By.Id("text-input-where"));
            where.SendKeys(waar);
            Thread.Sleep(200);

            where.Submit();

            // advanced search
            var advanced_search = driver.FindElement(By.CssSelector("#jobsearch > a"));
            advanced_search.Click();

            // select 3 days
            IWebElement selectAge = driver.FindElement(By.Id("fromage"));
            var select3Days = new SelectElement(selectAge);
            select3Days.SelectByIndex(3);

            // display 30 jobs on screen
            IWebElement selectDisplay = driver.FindElement(By.Id("limit"));
            var selectD = new SelectElement(selectDisplay);
            selectD.SelectByIndex(2);

            // sorted by date
            IWebElement selectSorted = driver.FindElement(By.Id("sort"));
            var selectS = new SelectElement(selectSorted);
            selectS.SelectByIndex(1);

            // enter
            var button = driver.FindElement(By.Id("fj"));
            button.Click();

            // haal popup weg als hij verschijnt
            var popup = driver.FindElement(By.CssSelector("#popover-x > button"));
            Thread.Sleep(200);
            if (popup != null)
            {
                popup.Click();
                Thread.Sleep(200);
            }

            Thread.Sleep(3000);

            // reclame in job lijst weg halen
            var reclame = driver.FindElement(By.CssSelector("#vjs-x > button"));
            reclame.Click();
            Thread.Sleep(200);

            var jobs = driver.FindElements(By.ClassName("tapItem"));

            // list met titels van de jobs
            List<string> jobTitles = new List<string>();
            // list met bedrijf namen
            List<string> companys = new List<string>();
            // list met locaties
            List<string> locations = new List<string>();
            // list met links
            List<string> hrefs = new List<string>();

            foreach (var item in jobs)
            {
                // voeg job titels toe aan list jobTitles
                var title = item.FindElement(By.XPath(".//div[1]/div/div[1]/div/table[1]/tbody/tr/td/div[1]/h2/span"));
                jobTitles.Add(title.Text);

                // voeg bedrijf toe aan list company
                var bedrijf = item.FindElement(By.ClassName("companyName"));
                companys.Add(bedrijf.Text);

                // voeg locatie toe aan list locations
                var locatie = item.FindElement(By.XPath(".//div[1]/div/div[1]/div/table[1]/tbody/tr/td/div[2]/pre/div"));
                locations.Add(locatie.Text);

                // voeg link toe aan list hrefs
                var link = item.GetAttribute("href");
                hrefs.Add(link);

                aantalJobs++;
            }

            for (int i = 0; i < aantalJobs; i++)
            {
                InD vacature = new InD { JobTitle = jobTitles[i], Company = companys[i], Location = locations[i], Href = hrefs[i] };
                InDeed.Add(vacature);
                youtubeRepository.InsertIndeed(vacature);
            }

            driver.Close();
        }
    }
}
