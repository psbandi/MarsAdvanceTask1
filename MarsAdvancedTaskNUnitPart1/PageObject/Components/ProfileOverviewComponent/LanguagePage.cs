using MarsAdvancedTaskNUnitPart1.Utilities;
using OpenQA.Selenium;


namespace MarsAdvancedTaskNUnitPart1.PageObject.Components.ProfileOverviewComponent
{
    public class LanguagePage : CommonDriver
    {
        //Parameterized Constructor
        public LanguagePage(IWebDriver driver) : base(driver)
        {
            
        }

        // Default Constructor
        public LanguagePage() 
        {
            
        }

        // Web Elements

        public IWebElement LanguageTab => driver.FindElement(By.XPath("//a[contains(text(),'Languages')]"));
        public IWebElement AddNewButton => driver.FindElement(By.XPath("//*[@class='ui teal button ']"));
        public IWebElement LanguageTextbox => driver.FindElement(By.XPath("//*[@placeholder='Add Language']"));
        public IWebElement chooseLevelDropdown => driver.FindElement(By.XPath("//*[@class='ui dropdown']"));
        public IWebElement chooseLevelOption => driver.FindElement(By.XPath("//*[@value='\" + Level + \"']"));
        public IWebElement AddButton => driver.FindElement(By.XPath("//input[@value='Add']"));
        public IWebElement CancelButton => driver.FindElement(By.XPath("//input[@value='Cancel']"));
        public IWebElement ToolTipMessage => driver.FindElement(By.XPath("//*[@class='ns-box-inner']"));
        public IWebElement EditLanguageTextbox => driver.FindElement(By.XPath("//*[@placeholder='Add Language']"));
        public IWebElement EditChooseLevelDropdown => driver.FindElement(By.XPath("//*[@class='ui dropdown']"));
        public IWebElement EditPencilIcon => driver.FindElement(By.XPath("//div[@id='account-profile-section']//form//table//tbody[2]/tr/td[3]/span[1]/i"));
        public IWebElement UpdateButton => driver.FindElement(By.XPath("//input[@value='Update']"));
        public IWebElement EditChooseLevelOption => driver.FindElement(By.XPath("//*[@value='\" + newLevel + \"']"));
        public IWebElement LastDeleteIcon => driver.FindElement(By.XPath("//table[1]/tbody[last()]//i[@class='remove icon']"));

        public IList<IWebElement> LanguageRows => driver.FindElements(By.XPath("//div[@data-tab='first']//table/tbody"));

        //Methods
        public void Click_LanguageTab()
        {
            WaitUtils.WaitToBeVisible(driver, "Xpath", "LanguageTab", 10);
            LanguageTab.Click();
        }


        public void CreateLanguageRecord(string Language, string Level)
        {
            // Click on Add New button
            WaitUtils.WaitToBeVisible(driver, "Xpath", "AddNewButton", 10);
            AddNewButton.Click();

            // Enter Language    
            LanguageTextbox.Click();
            LanguageTextbox.SendKeys(Language);

            // Select Language Level from dropdown list
            WaitUtils.WaitToBeVisible(driver, "Xpath", "chooseLevelDropdown", 5);
            chooseLevelDropdown.Click();
            
            driver.FindElement(By.XPath("//*[@value='" + Level + "']")).Click();
            

            // Click on save button
            WaitUtils.WaitToBeVisible(driver, "Xpath", "AddButton", 5);
            AddButton.Click();
          

        }

        public void EditLanguageRecord(string oldLanguage, string newLanguage, string oldLevel, string newLevel)
        {

            // click edit pencil icon for the existing record
            WaitUtils.WaitToBeVisible(driver, "Xpath", "EditPencilIcon", 5);
            EditPencilIcon.Click();
            
            if (newLanguage.Length > 0)
            {
                EditLanguageTextbox.Clear();
                EditLanguageTextbox.SendKeys(newLanguage);
            }

            if (newLevel.Length > 0)
            {
                EditChooseLevelDropdown.Click();
                WaitUtils.WaitToBeVisible(driver, "Xpath", "EditChooseLevelDropdown", 5);

                IWebElement EditChooseLevelOption = driver.FindElement(By.XPath("//*[@value='" + newLevel + "']"));
                EditChooseLevelOption.Click();

            }

            WaitUtils.WaitToBeVisible(driver, "Xpath", "UpdateButton", 5);
            UpdateButton.Click();
           
        }

        //To Delete Last Language records
        public void DeleteLastLanguageRecords()
        {
            
            LastDeleteIcon.Click();
            Thread.Sleep(1000);
        }

        //To Delete specific Language records
        public void DeletespecificLanguageRecords(string newLanguage)
        {

            for (int i = 1; i <= LanguageRows.Count; i++)
            {
                var getLanguageName = driver.FindElement(By.XPath($"//div[@data-tab='first']//table/tbody[{i}]/tr/td[1]")).Text;

                if(getLanguageName == newLanguage)
                {
                  
                    IWebElement specificDeleteIcon = driver.FindElement(By.XPath($"//table[1]/tbody[{i}]//i[@class='remove icon']"));
                    specificDeleteIcon.Click();
                    Thread.Sleep(1000);
                }
            }

        }

    }
}
