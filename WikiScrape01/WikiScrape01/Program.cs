using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiScrape01
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new PhantomJSDriver();

            var url = "http://en.wikipedia.org/wiki/Web_scraping";

            driver.Navigate().GoToUrl(url);

            var titles = driver.FindElements(By.CssSelector("#firstHeading"));

            var myFirstScrape = titles.First().Text;

            Console.WriteLine(myFirstScrape);
            Console.ReadLine();
        }
    }
}
