using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanspoonScraper
{
    class Program
    {
        static void Main(string[] args)
        {

            IWebDriver driver = new PhantomJSDriver();

            var url = "http://www.urbanspoon.com/r/1/1291/restaurant/Internacional-District/Seattle-Deli-Seattle";

            driver.Navigate().GoToUrl(url);


            var name = driver.FindElements(By.CssSelector("span6>h1")).First().Text;
            var phone = driver.FindElements(By.CssSelector(".phone.tel")).First().Text;
            var rating = driver.FindElements(By.CssSelector(".avarage.digits.rating")).First().Text.Split('\r')[0];
            var votes = driver.FindElements(By.CssSelector(".total")).First().Text.Split(' ')[0];

            var sw = new StreamWriter(@"output.csv");
            var csvWriter = new CsvHelper.CsvWriter(sw);

            csvWriter.WriteField(name);
            csvWriter.WriteField(phone);
            csvWriter.WriteField(rating);
            csvWriter.WriteField(votes);

            csvWriter.NextRecord();

            csvWriter.WriteField(name+" Hello! ");
            csvWriter.WriteField(phone);
            csvWriter.WriteField(rating);
            csvWriter.WriteField(votes);

            csvWriter.NextRecord();

            sw.Flush();
        }
    }
}
