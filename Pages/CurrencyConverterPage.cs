using NUnit.Framework;
using OpenQA.Selenium;
using System.Reflection.Emit;
using System.Xml.Linq;
using TechTalk.SpecFlow;
using XEConverterTests.HelperMethods;
using XEConverterTests.Utilities;

namespace XEConverterTests.Pages
{
    public class CurrencyConverterPage : Helpers
    {

        // Define locators
        private By AcceptCookie = By.XPath("//button[text()='Accept']");
        private By amountInput = By.CssSelector("input#amount");
        private By homepage = By.XPath("//h1[text()='Xe Currency Converter']");
        private By fromCurrency = By.XPath("(//input[@type='text'])[2]");        
        private By toCurrency = By.XPath("(//input[@type='text'])[3]");        
        private By convertButton = By.XPath("//button[text()='Convert']");
        private By convertedAmount = By.XPath("//p[contains(@class, 'sc-63d8b7e3-1')]");
        private By exchangeRates = By.XPath($"//div[contains(@class, 'sc-98b4ec47-0')]");
        private By negativeAmountError = By.XPath("//div[@class='sc-52d95371-0 fkpUOL relative top-1']");
        private By negativeAmountInput = By.Id("amount");
        private By invalidAmountError = By.XPath("//div[@class='sc-52d95371-0 fkpUOL relative top-1']");
        private By invertCurrencies = By.XPath("//button[@aria-label='Swap currencies']//*[name()='svg']");
        private By fromCurrencyDropdown = By.XPath("//input[@aria-describedby='midmarketFromCurrency-current-selection']");
        private By toCurrencyDropdown = By.XPath("//input[@aria-describedby='midmarketToCurrency-current-selection']");

        IWebElement myElement;
        public void sendKeys(string strElement, String value)
        {

            switch (strElement)
            {
                case "amountInput": myElement = GetWebDriver.driver.FindElement(amountInput); break;
                case "fromCurrency": myElement = GetWebDriver.driver.FindElement(fromCurrency); break;
                case "toCurrency": myElement = GetWebDriver.driver.FindElement(toCurrency); break;
                case "negativeAmountInput": myElement = GetWebDriver.driver.FindElement(negativeAmountInput); break;
            }
            sendKeysFunction(myElement, value);

        }
        public void findAndClick(string strElement)
        {

            switch (strElement)
            {
                case "AcceptCookie": myElement = GetWebDriver.driver.FindElement(AcceptCookie); break;
                case "amountInput": myElement = GetWebDriver.driver.FindElement(amountInput); break;
                case "convertButton": myElement = GetWebDriver.driver.FindElement(convertButton); break;
                case "fromCurrency": myElement = GetWebDriver.driver.FindElement(fromCurrency); break;
                case "toCurrency": myElement = GetWebDriver.driver.FindElement(toCurrency); break;
                case "negativeAmountInput": myElement = GetWebDriver.driver.FindElement(negativeAmountInput); break;
                case "invertCurrencies": myElement = GetWebDriver.driver.FindElement(invertCurrencies); break;
            }
            clickFunction(myElement);

        }
        public void findAndClearKey(string strElement)
        {
            switch (strElement)
            {
                case "negativeAmountInput": myElement = GetWebDriver.driver.FindElement(negativeAmountInput); break;
            }
            clickFunction(myElement);

            for (var i = 0; i < 3; i++)
            {
                myElement.SendKeys(Keys.Backspace);
                myElement.SendKeys(Keys.Delete);
            }
        }
        public void findAndContainsText(String strElement, String text)
        {
            switch (strElement)
            {
                case "homepage": myElement = GetWebDriver.driver.FindElement(homepage); break;
                case "convertedAmount": myElement = GetWebDriver.driver.FindElement(convertedAmount); break;
                case "exchangeRates": myElement = GetWebDriver.driver.FindElement(exchangeRates); break;
                case "negativeAmountError": myElement = GetWebDriver.driver.FindElement(negativeAmountError); break;
                case "invalidAmountError": myElement = GetWebDriver.driver.FindElement(invalidAmountError); break;                    
            }            

            verifyContainsText(myElement, text);
        }
        public void NavigateToHomePage()
        {
            GetWebDriver.InitializeDriver();
            GetWebDriver.driver.Navigate().GoToUrl("https://www.xe.com/currencyconverter/");
            GetWebDriver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            GetWebDriver.driver.Manage().Window.Maximize();    
        }
        public void NavigateToSpecificURL(string URL)
        {
            GetWebDriver.InitializeDriver();
            GetWebDriver.driver.Navigate().GoToUrl(URL);
            GetWebDriver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            GetWebDriver.driver.Manage().Window.Maximize();
        }

        public string findAndReturnText(String strElement)
        {
            switch (strElement)
            {
                case "exchangeRates": myElement = GetWebDriver.driver.FindElement(exchangeRates); break;
                case "convertedAmount": myElement = GetWebDriver.driver.FindElement(convertedAmount); break;
            }

            return getText(myElement);
        }

        public void findAndCompareList(String strElement)
        {
            switch (strElement)
            {
                case "fromCurrencyDropdown": myElement = GetWebDriver.driver.FindElement(fromCurrencyDropdown); break;
                case "toCurrencyDropdown": myElement = GetWebDriver.driver.FindElement(toCurrencyDropdown); break;
            }

            verifyCurrencyDropdownListing(myElement);
        }
        public void verifyExpectedAndActualAmountsEqual(double expectedConversionAmount, double actualConversionAmount)
        {
            // waitUntilVisible(element);
            GetWebDriver.Wait(1);
            Assert.AreEqual(expectedConversionAmount, actualConversionAmount);
        }
        public void verifyExpectedAndActualURLsEqual(string expectedURL, string currentURL)
        {
            // waitUntilVisible(element);
            GetWebDriver.Wait(1);
            Assert.AreEqual(expectedURL, currentURL);
        }

    }
}