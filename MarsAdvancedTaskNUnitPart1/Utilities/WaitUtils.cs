using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MarsAdvancedTaskNUnitPart1.Utilities
{
    public class WaitUtils
    {
        public static void WaitMethod(IWebDriver driver, string waittype, By locator, int seconds)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));

            //example explicit wait(requires an expected condition & build each wait in ever single element)
            //Most applicable in ElementExists, ElementIsVisible, ElementToBeClickable                        

            if (waittype == "ElementIsVisible")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
            }
            else if (waittype == "ElementToBeClickable")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
            }
            else if (waittype == "ElementExists")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
            }
            
        }       

    }
}
