using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using XEConverterTests.Utilities;

namespace XEConverterTests.HelperMethods
{
    public class Helpers
    {
        public void sendKeysFunction(IWebElement element, String value)
        {
            // waitUntilVisible(element); 
            // scrollToElement(element);
            GetWebDriver.Wait(3);
            element.Clear();
            element.SendKeys(value);
        }

        //   public void waitUntilVisible(IWebElement element)
        //   {
        //       WebDriverWait wait = new WebDriverWait(GWD.driver, TimeSpan.FromSeconds(30));
        //       wait.Until(ExpectedConditions.ElementExists(element));
        //   }

        public void clickFunction(IWebElement element)
        {
            //  waitUntilClickable(element);
            //  scrollToElement(element);
            GetWebDriver.Wait(2);
            element.Click();
        }
        public void verifyContainsText(IWebElement element, string text)
        {
            // waitUntilVisible(element);
            GetWebDriver.Wait(1);
            Assert.True(element.Text.ToLower().Contains(text.ToLower()));
        }
        public void verifyCurrencyDropdownListing(IWebElement element)
        {
            // waitUntilVisible(element);
            GetWebDriver.Wait(1);
            SelectElement dropdown = new SelectElement(element);
            List<string> dropdownListing = dropdown.Options.Select(option => option.Text).ToList();
            List<string> expectedDropdownListing = new List<string>
                                                     {
                                                         "USD US Dollar",
                                                         "EUR Euro",
                                                         "GBP British Pound",
                                                         "CAD Canadian Dollar",
                                                         "AUD Australian Dollar"
                                                     };

            for (var i = 0; i < expectedDropdownListing.Count; i++)
            {
                Assert.True(dropdownListing[i].Equals(expectedDropdownListing[i]));

                Console.WriteLine(dropdownListing[i] + expectedDropdownListing[i]);
            }

        }
        public void pressEnter()
        {
            GetWebDriver.Wait(2);
            Actions actions = new Actions(GetWebDriver.driver);
            actions.SendKeys(Keys.Enter).Perform();
        }
        public string getText(IWebElement element)
        {
            return element.Text;
        }
        public string toCurrencyRate(string strExchangeRates, string fromCurrency, string toCurrency)
        {
            string input = strExchangeRates;
            string pattern = $"1 {toCurrency} = ([0-9]+\\.[0-9]+) {fromCurrency}";
            Match match = Regex.Match(input, pattern);
            string strExchangeRate = match.Groups[1].Value;

            return strExchangeRate;
        }

        public double expectedConversionAmount(string amount, string strExchangeRates, string fromCurrency, string toCurrency)
        {
            var strToCurrencyRate = toCurrencyRate(strExchangeRates, toCurrency, fromCurrency);

            var expectedConvertedAmount = stringToDouble(amount) * stringToDouble(strToCurrencyRate);

            return Math.Round(expectedConvertedAmount, 2);
        }

        public double actualConversionAmount(string convertedAmount)
        {
            string input = convertedAmount;
            string pattern = @"^\d+(\.\d+)?"; // Matches a number (integer or decimal) at the start of the string
            Match match = Regex.Match(input, pattern);
            double actualConversionAmount = double.Parse(match.Value);

            return Math.Round(actualConversionAmount, 2);
        }

        public double stringToDouble(string strAmount)
        {
            var doubleAmount = double.Parse(strAmount);
            return doubleAmount;
        }
        public void refreshPage()
        {
            GetWebDriver.Wait(2);
            GetWebDriver.driver.Navigate().Refresh();
            GetWebDriver.Wait(3);
        }
        public string getCurrentURL()
        {
            GetWebDriver.Wait(2);
            string URL = GetWebDriver.driver.Url;
            GetWebDriver.Wait(2);
            return URL;
        }
        public string generateExpectedURL(string Amount, string fromCurrency, string toCurrency)
        {
            var expectedURL = $"https://www.xe.com/currencyconverter/convert/?Amount={Amount}" +
                $"&From={fromCurrency}&To={toCurrency}";
            return expectedURL;
        }
        public void takefromCurrencyDropdownScreenshot()
        {
            takeScreenShots("fromCurrency");
        }
        public void taketoCurrencyDropdownScreenshot()
        {
            takeScreenShots("toCurrency");
        }
        public void takeScreenShots(string fileName)
        {
            var projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            var screenshotsPath = Path.Combine(projectPath, "\\ScreenShots");
            DateTime currentDate = DateTime.Now;
            string photoname = fileName + currentDate.ToString("MMddyyyyHHmm") + ".png";
            Screenshot ss = ((ITakesScreenshot)GetWebDriver.driver).GetScreenshot();
            ss.SaveAsFile(@"C:\XEConverterTests\XEConverterTests\ScreenShots\" + photoname);

        }
    }
}


