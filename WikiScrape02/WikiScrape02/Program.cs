using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiScrape02
{
    class Program
    {
        static void Main(string[] args)
        {

            IWebDriver driver = new PhantomJSDriver();

            var url = "http://en.wikipedia.org/wiki/Web_scraping";

            driver.Navigate().GoToUrl(url);

            var tocElements = driver.FindElements(By.CssSelector("#toc>ul"));

            var allElements = tocElements[0].FindElements(By.TagName("li"));

            var allRefs = new List<string>();

            foreach(var item in allElements)
            {
                var textOnly = String.Join(" ",item.Text.Split(' ').Skip(1));
                allRefs.Add(textOnly);
            }

            Console.WriteLine(allRefs.ToString());
            Console.Read();

        }
    }
}
