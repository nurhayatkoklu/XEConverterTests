using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace XEConverterTests.Utilities
{
    public class GetWebDriver
    {
        public static IWebDriver driver;
        public static ChromeOptions chromeOptions= new ChromeOptions();




        public static IWebDriver InitializeDriver()
      {
          if (driver == null)
          {
            //chromeOptions.AddArguments(new List<string>() { "headless" });
            //  var chromeDriverService = ChromeDriverService.CreateDefaultService();
            //  ChromeDriver driver = new ChromeDriver(chromeDriverService, chromeOptions);
              driver = new ChromeDriver(SetUp.chromeDriverPath);
          }
            return driver;
      }

        public static void QuitDriver()
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null;
            }

        }
        public static void Wait(int seconds)
        {
            try
            {
                Thread.Sleep(seconds * 1000);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

    }



}
