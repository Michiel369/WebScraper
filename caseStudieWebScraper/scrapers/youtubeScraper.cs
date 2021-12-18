using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using caseStudieWebScraper.Models;
using caseStudieWebScraper.DAL;

namespace caseStudieWebScraper.scrapers
{
    class youtubeScraper
    {
        private static IWebDriver driver;

        public static void Scrape(string zoekWoord, HashSet<YT> YTVideos, YoutubeRepository youtubeRepository)
        {
            // Chrome driver 96
            driver = new ChromeDriver("../../../Drivers");

            // own driver in bin map
            /* driver = new ChromeDriver(); */

            driver.Navigate().GoToUrl("https://www.youtube.com/");

            var popup = driver.FindElement(By.XPath("//*[@id=\"content\"]/div[2]/div[5]/div[2]/ytd-button-renderer[2]/a"));
            popup.Click();
            Thread.Sleep(2000);

            var zoekbalk = driver.FindElement(By.XPath("/html/body/ytd-app/div/div/ytd-masthead/div[3]/div[2]/ytd-searchbox/form/div[1]/div[1]/input"));
            zoekbalk.Click();
            zoekbalk.SendKeys(zoekWoord);
            var zoekKnop = driver.FindElement(By.XPath("/html/body/ytd-app/div/div/ytd-masthead/div[3]/div[2]/ytd-searchbox/button"));
            zoekKnop.Click();
            Thread.Sleep(2500);

            var videos = driver.FindElements(By.CssSelector("ytd-video-renderer.style-scope.ytd-item-section-renderer"));

            // Video titles
            List<string> titles = new List<string>();
            // Video uploaders
            List<string> uploaders = new List<string>();
            // video views
            List<string> views = new List<string>();
            // video links
            List<string> links = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                // video titles
                var title = videos[i].FindElements(By.Id("video-title"));
                foreach (var item in title)
                {
                    titles.Add(item.Text);
                }

                // video uploaders
                //var uploader = videos[i].FindElements(By.Id("text"));
                var uploader = videos[i].FindElements(By.CssSelector("#channel-info"));
                foreach (var item in uploader)
                {
                    //Console.WriteLine(item.Text);
                    uploaders.Add(item.Text);
                }

                //video views
                var view = videos[i].FindElements(By.CssSelector("#metadata-line > span:nth-child(1)"));
                foreach (var item in view)
                {
                    //Console.WriteLine(item.Text);
                    views.Add(item.Text);
                }

                // video links
                var link = videos[i].FindElements(By.Id("thumbnail"));
                foreach (var item in link)
                {
                    var href = item.GetAttribute("href");
                    links.Add(href);
                }
            }

            for (int i = 0; i < 5; i++)
            {
                YT video = new YT { Title = titles[i], Uploader = uploaders[i], View = views[i], Link = links[i] };
                YTVideos.Add(video);
                youtubeRepository.InsertYT(video);
            }

            driver.Close();
        }
    }
}
