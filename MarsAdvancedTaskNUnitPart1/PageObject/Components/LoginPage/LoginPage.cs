using MarsAdvancedTaskNUnitPart1.Models.LoginModel;
using MarsAdvancedTaskNUnitPart1.Models.ProfileOverviewModel;
using MarsAdvancedTaskNUnitPart1.Utilities;
using MarsAdvancedTaskNUnitPart1.Utilities.JsonReader.ProfileOverviewComponent;
using OpenQA.Selenium;
namespace MarsAdvancedTaskNUnitPart1.PageObject.Components.LoginPage
{
    public class LoginPage : CommonDriver
    {

        public LoginPage() : base()
        {

        }
        public LoginPage(IWebDriver driver) : base(driver)
        {

        }

        //Locator
        By loginButtonLocator => By.XPath("//button[contains(text(),'Login')]");
        By UsernameLocator => By.XPath("//*[@class='item ui dropdown link']");

        //Web Elements
        public IWebElement SignINButton => driver.FindElement(By.XPath("//a[@class='item'][(text()='Sign In')]"));
        public IWebElement EmailAddressTextbox => driver.FindElement(By.XPath("//input[@Placeholder='Email address']"));
        public IWebElement PasswordTextbox => driver.FindElement(By.XPath("//input[@Placeholder='Password']"));
        public IWebElement LoginButton => driver.FindElement(loginButtonLocator);
        public IWebElement Username => driver.FindElement(UsernameLocator);

        //Method
        public void ClickSignIn()
        {
            SignINButton.Click();
        }

        public void ValidLoginSteps(LoginModel loginModel)
        {
            
            EmailAddressTextbox.SendKeys(loginModel.EmailAddress);
            PasswordTextbox.SendKeys(loginModel.Password);

            WaitUtils.WaitMethod(driver, "ElementToBeClickable", loginButtonLocator, 5);
            LoginButton.Click();
        }

        public Boolean verifyLogin(string expectedUsername)
        {
            WaitUtils.WaitMethod(driver, "ElementIsVisible", UsernameLocator, 5);
            if (Username.Text.Contains(expectedUsername))
            {
                return true;
            }
            else
            {
                return false;
            }

        }


    }
}
