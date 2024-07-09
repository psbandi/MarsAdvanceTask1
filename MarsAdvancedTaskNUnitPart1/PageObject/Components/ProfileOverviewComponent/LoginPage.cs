﻿using MarsAdvancedTaskNUnitPart1.Utilities;
using OpenQA.Selenium;
namespace MarsAdvancedTaskNUnitPart1.PageObject.Components.ProfileOverviewComponent
{

    public class LoginPage : CommonDriver
    {
        
        public LoginPage() : base()
        {
        
        }
        public LoginPage(IWebDriver driver) : base(driver)
        {

        }

        //Web Elements
        public IWebElement SignINButton => driver.FindElement(By.XPath("//a[@class='item'][(text()='Sign In')]"));
        public IWebElement EmailAddressTextbox => driver.FindElement(By.XPath("//input[@Placeholder='Email address']"));
        public IWebElement PasswordTextbox => driver.FindElement(By.XPath("//input[@Placeholder='Password']"));
        public IWebElement LoginButton => driver.FindElement(By.XPath("//button[contains(text(),'Login')]"));

        //Method
        public void ClickSignIn()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            SignINButton.Click();
        }

        public void ValidLoginSteps(string EmailAddress, string Password)
        {
            EmailAddressTextbox.SendKeys(EmailAddress);
            PasswordTextbox.SendKeys(Password);
            
            WaitUtils.WaitToBeClickable(driver, "Xpath", "LoginButton", 10);
            LoginButton.Click();
        }

    }
}