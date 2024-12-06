using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using TechTalk.SpecFlow;
using XEConverterTests.Utilities;

namespace XEConverterTests.StepDefinitions
{
        [Binding]
        public class Hook

        {
        private static ExtentReports _extent;
        private static ExtentTest _test;

        [BeforeTestRun]
        public static void InitializeReport()
        {
            var sparkReporter = new ExtentSparkReporter("TestResults.html");
            _extent = new ExtentReports();
            _extent.AttachReporter(sparkReporter);
        }
        [AfterScenario]
        public void AfterScenario()
        {
            var scenario = ScenarioContext.Current.ScenarioInfo;
            _test = _extent.CreateTest(scenario.Title);

            if (ScenarioContext.Current.TestError != null)
            {
                _test.Fail(ScenarioContext.Current.TestError.Message);
            }
            else
            {
                _test.Pass("Test passed successfully.");
            }
            GetWebDriver.QuitDriver();
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            _extent.Flush();
        }


    }
    }

