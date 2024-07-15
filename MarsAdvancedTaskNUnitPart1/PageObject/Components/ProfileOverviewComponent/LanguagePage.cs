using MarsAdvancedTaskNUnitPart1.Models.ProfileOverviewModel;
using MarsAdvancedTaskNUnitPart1.Utilities;
using MarsAdvancedTaskNUnitPart1.Utilities.JsonReader.ProfileOverviewComponent;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace MarsAdvancedTaskNUnitPart1.PageObject.Components.ProfileOverviewComponent
{
    public class LanguagePage : CommonDriver
    {
        //Parameterized Constructor
        public LanguagePage(IWebDriver driver) : base(driver)
        {
            
        }

        // Default Constructor
        public LanguagePage() : base()
        {
            
        }


        //Locators
        By ProfileTabLocator => By.XPath("//section//a[@href='/Account/Profile']");
        By LanguageTabLocator => By.XPath("//a[contains(text(),'Languages')]");
        By AddNewButtonLocator => By.XPath("//*[@class='ui teal button ']");       
        By LanguageTextboxLocator => By.XPath("//*[@placeholder='Add Language']");
        By chooseLevelDropdownLocator => By.XPath("//*[@class='ui dropdown']");       
        By AddButtonLocator => By.XPath("//input[@value='Add']");
        By CancelButtonLocator => By.XPath("//input[@value='Cancel']");
        By ToolTipMessageLocator => By.XPath("//*[@class='ns-box-inner']");
        By EditLanguageTextboxLocator => By.XPath("//*[@placeholder='Add Language']");
        By EditChooseLevelDropdownLocator => By.XPath("//*[@class='ui dropdown']");
        By EditPencilIconDropdownLocator => By.XPath("//div[@id='account-profile-section']//form//table//tbody[2]/tr/td[3]/span[1]/i");
        By UpdateButtonLocator => By.XPath("//input[@value='Update']");
        By EditChooseLevelOptionLocator => By.XPath("//*[@value='\" + newLevel + \"']");
        By LastDeleteIconLocator => By.XPath("//table[1]/tbody[last()]//i[@class='remove icon']");
        By LanguageRowsLocator => By.XPath("//div[@data-tab='first']//table/tbody");



        // Web Elements
        public IWebElement ProfileTab => driver.FindElement(ProfileTabLocator);
        public IWebElement LanguageTab => driver.FindElement(LanguageTabLocator);
        public IWebElement AddNewButton => driver.FindElement(AddNewButtonLocator);
        public IWebElement LanguageTextbox => driver.FindElement(LanguageTextboxLocator);
        public IWebElement chooseLevelDropdown => driver.FindElement(chooseLevelDropdownLocator);
        public IWebElement AddButton => driver.FindElement(AddButtonLocator);
        public IWebElement CancelButton => driver.FindElement(CancelButtonLocator);
        public IWebElement ToolTipMessage => driver.FindElement(ToolTipMessageLocator);
        public IWebElement EditLanguageTextbox => driver.FindElement(EditLanguageTextboxLocator);
        public IWebElement EditChooseLevelDropdown => driver.FindElement(EditChooseLevelDropdownLocator);
        public IWebElement EditPencilIcon => driver.FindElement(EditPencilIconDropdownLocator);
        public IWebElement UpdateButton => driver.FindElement(UpdateButtonLocator);
        public IWebElement EditChooseLevelOption => driver.FindElement(EditChooseLevelOptionLocator);
        public IWebElement LastDeleteIcon => driver.FindElement(LastDeleteIconLocator);
        public IList<IWebElement> LanguageRows => driver.FindElements(LanguageRowsLocator);
        

        //Methods
        public void NavigateToLanguageTab()
        {
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            WaitUtils.WaitMethod(driver, "ElementIsVisible", ProfileTabLocator, 5);
            ProfileTab.Click();

            WaitUtils.WaitMethod(driver, "ElementIsVisible", LanguageTabLocator, 5);
            LanguageTab.Click();
        }


        public void CreateLanguageRecord(LanguageModel languageModel)
        {
            By chooseLevelOptionLocator = By.XPath("//*[@value='" + languageModel.Level + "']");

            // Click on Add New button
            WaitUtils.WaitMethod(driver, "ElementIsVisible", AddNewButtonLocator, 5);
            AddNewButton.Click();

            // Enter Language
            WaitUtils.WaitMethod(driver, "ElementIsVisible", LanguageTextboxLocator, 5);
            if (!string.IsNullOrEmpty(languageModel.Language))
            {
                LanguageTextbox.Click();
                LanguageTextbox.SendKeys(languageModel.Language);
            }

            // Select Language Level from dropdown list
            WaitUtils.WaitMethod(driver, "ElementIsVisible", chooseLevelDropdownLocator, 5);
            if (!string.IsNullOrEmpty(languageModel.Level))
            {
                chooseLevelDropdown.Click();
                driver.FindElement(chooseLevelOptionLocator).Click();
                
            }
            
            // Click on save button
            WaitUtils.WaitMethod(driver, "ElementIsVisible", AddButtonLocator, 5);
            AddButton.Click();

        }

        //public void EditLanguageRecord(LanguageModel languageModel)
        //{

        //    // click edit pencil icon for the existing record
        //    WaitUtils.WaitToBeVisible(driver, "XPath", "//div[@id='account-profile-section']//form//table//tbody[2]/tr/td[3]/span[1]/i", 10);
        //    EditPencilIcon.Click();

        //    WaitUtils.WaitToBeVisible(driver, "XPath", "//*[@placeholder='Add Language']", 5);
        //    if (!string.IsNullOrEmpty(languageModel.Language))
        //    {
        //        EditLanguageTextbox.Clear();
        //        EditLanguageTextbox.SendKeys(languageModel.Language);
        //    }

        //    WaitUtils.WaitToBeClickable(driver, "XPath", "//*[@class='ui dropdown']", 5);
        //    if (!string.IsNullOrEmpty(languageModel.Level))
        //    {
        //        EditChooseLevelDropdown.Click();
               
        //        IWebElement EditChooseLevelOption = driver.FindElement(By.XPath("//*[@value='" + languageModel.Level + "']"));
        //        EditChooseLevelOption.Click();

        //    }

        //    WaitUtils.WaitToBeVisible(driver, "XPath", "//input[@value='Update']", 10);
        //    UpdateButton.Click();
           
        //}

        public bool IsLanguageRecordPresent(LanguageModel languageModel, int rowNumber = 0)
        {
            bool recordPresent = false;
            string getLanguage, getLevel;
            int languageRowPresent;
            By getLanguageLocator = By.XPath($"//div[@data-tab='first']//table/tbody[{rowNumber}]/tr/td[1]");
            By getLevelLocator = By.XPath($"//div[@data-tab='first']//table/tbody[{rowNumber}]/tr/td[2]");

            if (rowNumber == 0)
            {
                languageRowPresent = GetLanguageRow(languageModel);
                if (languageRowPresent > 0)
                {
                    recordPresent = true;
                }
            }
            else
            {
                WaitUtils.WaitMethod(driver, "ElementIsVisible", getLanguageLocator, 5);
                getLanguage = driver.FindElement(getLanguageLocator).Text;
                WaitUtils.WaitMethod(driver, "ElementIsVisible", getLevelLocator, 5);
                getLevel = driver.FindElement(getLevelLocator).Text;
                

                ReportLogger.LogInfo($"Retrieved [row {rowNumber}]: Language: {getLanguage}, Level: {getLevel}");
                if (languageModel.Language.Equals(getLanguage) && languageModel.Level.Equals(getLevel)) 
                { 
                    recordPresent = true;
                }
            }

            return recordPresent;
        }

        public int RowCount() => LanguageRows.Count;

        public int GetLanguageRow(LanguageModel languageModel)
        {
            string getLanguage, getLevel;

            for (int i = 1; i <= RowCount(); i++)
            {
                try
                {
                    getLanguage = driver.FindElement(By.XPath($"//div[@data-tab='first']//table/tbody[{i}]/tr/td[1]")).Text;
                    getLevel = driver.FindElement(By.XPath($"//div[@data-tab='first']//table/tbody[{i}]/tr/td[2]")).Text;

                    if (languageModel.Language.Equals(getLanguage) && languageModel.Level.Equals(getLevel))
                    {
                        ReportLogger.LogInfo($"language Present at row: {i}");
                        return i;
                    }
                }
                catch (NoSuchElementException)
                {
                    continue;
                }
            }
            return 0;
        }


        public void SelectLanguageRecord(LanguageModel languageModel)
        {
            int rowNumber = GetLanguageRow(languageModel);
            if (rowNumber > 0)
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                var editButton = driver.FindElement(By.XPath($"//div[@data-tab='first']//table/tbody[{rowNumber}]//i[@class='outline write icon']"));
                editButton.Click();
            }

        }


        public void DeleteLastLanguageRecords()
        {
            WaitUtils.WaitMethod(driver, "ElementIsVisible", LastDeleteIconLocator, 10);
            LastDeleteIcon.Click();
        }

      
        public void ClearLanguage()
        {

            if (LanguageRows != null && LanguageRows.Count > 0)
            {

                int rowCount = LanguageRows.Count;

                for (int i = 1; i <= rowCount; i++)
                {
                    DeleteLastLanguageRecords();
                    Thread.Sleep(1000);
                }
            }

        }

    }
}
