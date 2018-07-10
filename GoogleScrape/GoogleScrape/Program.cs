using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleScrape
{
    class Program
    {
        static void Main(string[] args)
        {

            IWebDriver driver = new PhantomJSDriver();


            driver.Navigate().GoToUrl("https://www.google.com/#q=site:linkedin.com%2Fin%2F+jhon+tech");



            var allLinks = new List<string>();



            for (int i = 0; i < 30; i++)
            {

                List<string> linksList = ExtractElementsSinglePage(driver);

                allLinks.AddRange(linksList);

                var nextUrl = driver.FindElements(By.PartialLinkText("Next")).Last().GetAttribute("href");
                driver.Navigate().GoToUrl(nextUrl);

            }

            var uniqueUrls = allLinks.Distinct().ToList();

        }

        private static List<string> ExtractElementsSinglePage(IWebDriver driver)
        {
            var linksList = new List<string>();
            var potentialLinks = driver.FindElements(By.TagName("cite"));

            foreach (var link in potentialLinks)
            {
                var curLink = link.Text;
                if (curLink.Contains("linkedin.com"))
                    linksList.Add(curLink);
            }

            return linksList;
        }
    }
}
