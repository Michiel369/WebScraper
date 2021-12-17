using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using caseStudieWebScraper.Views;
using caseStudieWebScraper.Models;
using caseStudieWebScraper.DAL;

namespace caseStudieWebScraper.scrapers
{
    class HLNScraper
    {
        private static IWebDriver driver;
        public static void Scrape(string zoekTerm, HashSet<hln> Hln, YoutubeRepository youtubeRepository)
        {
            string zoekterm = zoekTerm;
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.hln.be/");
            Thread.Sleep(2000);

            // switch to iframe for cookie akkoort
            driver.SwitchTo().Frame("sp_message_iframe_584523");
            var test = driver.FindElement(By.ClassName("sp_choice_type_11"));
            test.Click();
            Thread.Sleep(2000);

            // zoek
            var zoek = driver.FindElement(By.ClassName("primary-nav__list-item--search"));
            zoek.Click();
            var zoekBalk = driver.FindElement(By.CssSelector("body > header > section.page-header__section--primary.fjs-hide-subnav > div.sub-nav.hide-on-mobile > div.sub-nav__search > div > form > input"));
            zoekBalk.Click();
            zoekBalk.SendKeys(zoekterm);
            zoekBalk.Submit();

            // data
            var artikels = driver.FindElements(By.ClassName("results__list-item"));

            // artikel namen
            List<string> namen = new List<string>();
            // artikel plaatsen
            List<string> plaatsen = new List<string>();
            // artikel beschrijvingen
            List<string> beschrijvingen = new List<string>();
            // artikel link
            List<string> aLinks = new List<string>();


            for (int i = 0; i < 5; i++)
            {
                // voeg namen toe aan list namen
                var naam = artikels[i].FindElement(By.ClassName("ankeiler__title"));
                namen.Add(naam.Text);

                // voeg plaatsen toe aan list plaatsen
                var plaats = artikels[i].FindElement(By.ClassName("label--plain"));
                plaatsen.Add(plaats.Text);

                // voeg beschrijvingen toe aan list beschrijvingen
                var beschrijving = artikels[i].FindElement(By.ClassName("ankeiler__body-text"));
                beschrijvingen.Add(beschrijving.Text);

                // voeg links toe aan list aLinks
                var aLink = artikels[i].FindElement(By.ClassName("ankeiler__link"));
                var link = aLink.GetAttribute("href");
                aLinks.Add(link);
            }

            for (int i = 0; i < 5; i++)
            {
                hln artikel = new hln { Naam = namen[i], Plaats = plaatsen[i], Beschrijving = beschrijvingen[i], ALink = aLinks[i] };
                Hln.Add(artikel);
                youtubeRepository.InsertHLN(artikel);
            }

            driver.Close();
        }
    }
}
