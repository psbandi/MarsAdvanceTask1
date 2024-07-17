using MarsAdvancedTaskNUnitPart1.PageObject.Components.LoginPage;
using MarsAdvancedTaskNUnitPart1.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;

namespace MarsAdvancedTaskNUnitPart1.Assertions
{
    public static class AssertionHelpers
    {
        public static void AssertToolTipMessage(CommonDriver page, string expectedMessage)
        {
            IWebDriver driver = page.getDriver();
            By toolTipLocator = By.XPath("//*[@class='ns-box-inner']");
            WaitUtils.WaitMethod(driver, "ElementIsVisible", toolTipLocator, 10);

            try
            {
                IWebElement toolTipMessage = driver.FindElement(toolTipLocator);

                string actualMessage = toolTipMessage.Text.Trim();

                Console.WriteLine("Tooltip Text: " + actualMessage);

                // Remove single quotes from the expected message
                string expectedMessageWithoutQuotes = expectedMessage.Replace("'", "");

                // Check if the actual message matches the expected message without quotes
                if (actualMessage == expectedMessageWithoutQuotes)
                {
                    // Log the success
                    Console.WriteLine("Tooltip message matches the expected message.");
                    ReportLogger.LogPass("Passed " + expectedMessage);
                }
                else
                {
                    // Log the failure and provide details about the differences
                    ReportLogger.LogFail("Failed " + expectedMessage);
                    Console.WriteLine($"Expected: '{expectedMessage}'");
                    Console.WriteLine($"But was:  '{actualMessage}'");
                    Assert.Fail("Tooltip message does not match the expected message.");
                }
            }

            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("Tooltip message did not appear within the expected time.");
                ReportLogger.LogFail("Failed to find the tooltip message.");
                Assert.Fail("Tooltip message did not appear within the expected time.");
            }
        }

        public static void AssertLogin(LoginPage loginPage, string expectedUsername)
        {
            Boolean LoggedIn = loginPage.verifyLogin(expectedUsername);

            Assert.That(LoggedIn, Is.True);

        }
    }
}
