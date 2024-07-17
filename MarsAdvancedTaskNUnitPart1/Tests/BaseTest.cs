using MarsAdvancedTaskNUnitPart1.Models.LoginModel;
using MarsAdvancedTaskNUnitPart1.PageObject.Components.LoginPage;
using MarsAdvancedTaskNUnitPart1.PageObject.Components.ProfileOverviewComponent;
using MarsAdvancedTaskNUnitPart1.Utilities;
using MarsAdvancedTaskNUnitPart1.Utilities.JsonReader;
using MarsAdvancedTaskNUnitPart1.Utilities.JsonReader.Login;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace MarsAdvancedTaskNUnitPart1.Tests
{

    public class BaseTest
    {

        protected IWebDriver driver;
        protected CommonDriver driverSetup;
        protected LoginPage loginPageObject;
        protected LanguagePage languagePageObject;
        protected SkillPage skillPageObject;
        protected List<LoginModel> loginModel;
        
        // Called once prior to executing any of the tests in a fixture
        [OneTimeSetUp]
        public void BaseFixtureSetup()
        {

            AppConfig config = AppConfig.LoadConfig();
            driverSetup = new CommonDriver();
            driver = driverSetup.Initialize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl(config.url);

            // Initialize the page objects
            loginPageObject = new LoginPage(driver);
            languagePageObject = new LanguagePage(driver);
            skillPageObject = new SkillPage(driver);

            // Perform login
            loginModel = LoginConfig.LoadConfig();
            loginPageObject.ClickSignIn();
            loginPageObject.ValidLoginSteps(loginModel[0]);
            //Assertions.AssertionHelpers.AssertLogin(loginPageObject, loginModel[0].Username);
        }

        public IWebDriver GetDriver()
        {
            return driver;
        }

        // Called once after executing any of the tests in a fixture
        [OneTimeTearDown]
        public void BaseFixtureTeardown()
        {
            ExtentManager.FlushReport();
            //ExtentManager.GetExtent().Flush();
            driver?.Dispose();
        }

        // Called before each test method in the derived class
        [SetUp]
        public void BaseSetup()
        {
            // Create a test for reporting
            ExtentManager.CreateTest(TestContext.CurrentContext.Test.Name);
                                                           
        }

        // Performed after each test method in derived class
        [TearDown]
        public void BaseTearDown()
        {
            try
            {
                // Log test results to ExtentReports
                EndTest();                                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception during tear down: {ex.Message}");
            }
            
        }
        public string TakeScreenshot()
        {
            var file = ((ITakesScreenshot)driver).GetScreenshot();
            var image = file.AsBase64EncodedString;

            return image;

        }

        public void EndTest()
        {
            var teststatus = TestContext.CurrentContext.Result.Outcome.Status;
            var message = TestContext.CurrentContext.Result.Message;

            switch (teststatus)
            {
                case TestStatus.Failed:
                    ReportLogger.LogFail($"Test has failed {message}");
                    ExtentManager.LogScreenshot("Ending test - Failure Screenshot", TakeScreenshot());
                    break;

                case TestStatus.Skipped:
                    ReportLogger.LogSkip($"Test skipped {message}");
                    break;

                case TestStatus.Passed:
                    ReportLogger.LogPass($"Test passed {message}");
                    break;

                default:
                    ReportLogger.LogInfo($"Test completed with status: {teststatus}");
                    break;
            }
                       
        }                               
        
    }
}
