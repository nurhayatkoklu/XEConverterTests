using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using XEConverterTests.Pages;
using XEConverterTests.Utilities;

namespace XEConverterTests.StepDefinitions
{
    [Binding]
    public class ConvertCurrencyTestSteps
    {
        CurrencyConverterPage ccp = new CurrencyConverterPage();

        [Given(@"Navigate To basqar")]
        public void GivenNavigateToBasqar()
        {
            ccp.NavigateToHomePage();
        }

        [When(@"Confirm you are on the Xe Currency Converter page")]
        public void WhenConfirmYouAreOnTheXeCurrencyConverterPage()
        {
            ccp.findAndContainsText("homepage", "Xe Currency Converter");

        }

        [When(@"Enter ""(.*)"" and, ""(.*)"" and ""(.*)""")]
        public void WhenEnterAndAnd(string Amount, string fromCurrency, string toCurrency)
        {
            ccp.findAndClick("amountInput");
            ccp.sendKeys("amountInput", Amount);

            ccp.findAndClick("fromCurrency");
            ccp.sendKeys("fromCurrency", fromCurrency);
            ccp.pressEnter();

            ccp.findAndClick("toCurrency");
            ccp.sendKeys("toCurrency", toCurrency);
            ccp.pressEnter();

        }
        [When(@"Enter Amount and source and target currency")]
        public void WhenEnterAmountAndSourceAndTargetCurrency()
        {
            ccp.findAndClick("amountInput");
            ccp.sendKeys("amountInput", "10");

            ccp.findAndClick("fromCurrency");
            ccp.sendKeys("fromCurrency", "EUR");
            ccp.pressEnter();

            ccp.findAndClick("toCurrency");
            ccp.sendKeys("toCurrency", "GBP");
            ccp.pressEnter();

        }

        [When(@"Click Convert button")]
        public void WhenClickConvertButton()
        {
            ccp.findAndClick("convertButton");

        }

        [Then(@"User should see converted amount in ""(.*)""")]
        public void ThenUserShouldSeeConvertedAmountIn(string toCurrencyName)
        {
            ccp.findAndContainsText("convertedAmount", toCurrencyName);

        }

        [Then(@"User should see exchange rate between source ""(.*)"" and target ""(.*)""")]
        public void ThenUserShouldSeeExchangeRateBetweenSourceAndTarget(string fromCurrency, string toCurrency)
        {
            var expectedExchangeRates = $"1 {fromCurrency} = ";
            ccp.findAndContainsText("exchangeRates", expectedExchangeRates);
        }

        [Then(@"User should see exchange rate between target ""(.*)"" and source ""(.*)""")]
        public void ThenUserShouldSeeExchangeRateBetweenTargetAndSource(string toCurrency, string fromCurrency)
        {
            var expectedExchangeRates = $"1 {toCurrency} = ";
            ccp.findAndContainsText("exchangeRates", expectedExchangeRates);

        }

        [Then(@"Converted amount ""(.*)"" from ""(.*)"" to ""(.*)"" should be mathematically correct")]
        public void ThenConvertedAmountFromToShouldBeMathematicallyCorrect(string Amount, string fromCurrency, string toCurrency)
        {
            var strExchangeRates = ccp.findAndReturnText("exchangeRates");
            var strConversionAmount = ccp.findAndReturnText("convertedAmount");

            var expConversionAmount = ccp.expectedConversionAmount(Amount, strExchangeRates, fromCurrency, toCurrency);
            var actualConversionAmount = ccp.actualConversionAmount(strConversionAmount);

            ccp.verifyExpectedAndActualAmountsEqual(expConversionAmount, actualConversionAmount);

        }
        [When(@"Click Source Currency Dropdown")]
        public void WhenClickSourceCurrencyDropdown()
        {
            ccp.findAndClick("fromCurrency");

        }

        [Then(@"Confirm Source Currency Dropdown first Lists Popular Currencies")]
        public void ThenConfirmSourceCurrencyDropdownFirstListsPopularCurrencies()
        {

            ccp.findAndCompareList("fromCurrencyDropdown");
        }

        [When(@"Click Target Currency Dropdown")]
        public void WhenClickTargetCurrencyDropdown()
        {
            ccp.findAndClick("toCurrency");

        }

        [Then(@"Confirm Target Currency Dropdown first Lists Popular Currencies")]
        public void ThenConfirmTargetCurrencyDropdownFirstListsPopularCurrencies()
        {
            ccp.findAndCompareList("toCurrencyDropdown");
        }

        [Then(@"User should see an error message")]
        public void ThenUserShouldSeeAnErrorMessage()
        {
            ccp.findAndContainsText("negativeAmountError", "Please enter an amount greater than 0");
            ccp.findAndContainsText("convertedAmount", "-");

        }

        [Then(@"User should see converted negative amount in ""(.*)""")]
        public void ThenUserShouldSeeConvertedNegativeAmountIn(string toCurrencyName)
        {
            ccp.findAndContainsText("convertedAmount", toCurrencyName);

        }
        [When(@"Enter negative ""(.*)"" and, ""(.*)"" and ""(.*)""")]
        public void WhenEnterNegativeAndAnd(string Amount, string fromCurrency, string toCurrency)
        {
            ccp.sendKeys("negativeAmountInput", Amount);

            ccp.findAndClick("fromCurrency");
            ccp.sendKeys("fromCurrency", fromCurrency);
            ccp.pressEnter();

            ccp.findAndClick("toCurrency");
            ccp.sendKeys("toCurrency", toCurrency);
            ccp.pressEnter();

        }
        [When(@"Refresh Page")]
        public void WhenRefreshPage()
        {
            ccp.refreshPage();
        }

        [When(@"Clear Amount Text Box")]
        public void WhenClearAmountTextBox()
        {
            ccp.findAndClearKey("negativeAmountInput");
        }

        [Then(@"User should see invalid amount error")]
        public void ThenUserShouldSeeInvalidAmountError()
        {
            ccp.findAndContainsText("invalidAmountError", "Please enter a valid amount");
        }

        [Then(@"Click Invert Currencies Button")]
        public void ThenClickInvertCurrenciesButton()
        {
            ccp.findAndClick("invertCurrencies");
        }

        [Then(@"User should see swapped amount in ""(.*)""")]
        public void ThenUserShouldSeeSwappedAmountIn(string fromCurrencyName)
        {
            ccp.findAndContainsText("convertedAmount", fromCurrencyName);
        }

        [Then(@"URL should contain ""(.*)"", ""(.*)"" in From and ""(.*)"" in To")]
        public void ThenURLShouldContainInFromAndInTo(string Amount, string fromCurrency, string toCurrency)
        {
            var expextedURL = ccp.generateExpectedURL(Amount, fromCurrency, toCurrency);
            var currentURL = ccp.getCurrentURL();
            ccp.verifyExpectedAndActualURLsEqual(expextedURL, currentURL);
        }

        [Then(@"Refresh Page")]
        public void ThenRefreshPage()
        {
            ccp.refreshPage();
        }

        [Then(@"URL should be updated, ""(.*)"" should stay as it is ""(.*)"" and ""(.*)"" should be swapped")]
        public void ThenURLShouldBeUpdatedShouldStayAsItIsAndShouldBeSwapped(string Amount, string fromCurrency, string toCurrency)
        {
            var expextedURL = ccp.generateExpectedURL(Amount, toCurrency, fromCurrency);
            var currentURL = ccp.getCurrentURL();
            ccp.verifyExpectedAndActualURLsEqual(expextedURL, currentURL);
        }

        [When(@"Get URL and go to this URL")]
        public void WhenGetURLAndGoToThisURL()
        {
            var currentURL = ccp.getCurrentURL();
            ccp.NavigateToSpecificURL(currentURL); 
        }

        [Then(@"Confirm that you are on the correct page by confirming ""(.*)""")]
        public void ThenConfirmThatYouAreOnTheCorrectPageByConfirming(string toCurrencyName)
        {
            ccp.findAndContainsText("convertedAmount", toCurrencyName);
        }

        [Then(@"Take screenshot of Source Currency Dropdown to confirm listing")]
        public void ThenTakeScreenshotOfSourceCurrencyDropdownToConfirmListing()
        {
           ccp.takefromCurrencyDropdownScreenshot();
        }

        [Then(@"Take screenshot of Target Currency Dropdown to confirm listing")]
        public void ThenTakeScreenshotOfTargetCurrencyDropdownToConfirmListing()
        {
           ccp.taketoCurrencyDropdownScreenshot();
        }





    }
}
