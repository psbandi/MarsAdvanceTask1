//using MarsAdvancedTaskNUnitPart1.Utilities;
//using OpenQA.Selenium;

//namespace MarsAdvancedTaskNUnitPart1.PageObject.Components.ProfileOverviewComponent
//{
//    public class SkillsPage : CommonDriver
//    {
//        public SkillsPage(IWebDriver driver) : base(driver)
//        {
//        }

//        public SkillsPage()
//        {
//        }

//        // Web Elements
//        public IWebElement ProfileTab => driver.FindElement(By.XPath("//section//a[@href='/Account/Profile']"));
//        public IWebElement SkillsTab => driver.FindElement(By.XPath("//a[contains(text(),'Skills')]"));
//        public IWebElement AddNewButton => driver.FindElement(By.XPath("//div[@class='ui teal button']"));
//        public IWebElement SkillsTextbox => driver.FindElement(By.XPath("//*[@placeholder='Add Skill']"));
//        public IWebElement chooseLevelDropdown => driver.FindElement(By.XPath("//*[@class='ui fluid dropdown']"));
//        public IWebElement chooseLevelOption => driver.FindElement(By.XPath("//*[@value='\" + Level + \"']"));
//        public IWebElement AddButton => driver.FindElement(By.XPath("//input[@value='Add']"));
//        public IWebElement CancelButton => driver.FindElement(By.XPath("//input[@value='Cancel']"));
//        public IWebElement ToolTipMessage => driver.FindElement(By.XPath("//*[@class='ns-box-inner']"));
//        public IWebElement EditSkillsTextbox => driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
//        public IWebElement EditChooseLevelDropdown => driver.FindElement(By.XPath("//*[@class='ui fluid dropdown']"));
//        public IWebElement EditPencilIcon => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[4]/tr/td[3]/span[1]/i"));
//        public IWebElement UpdateButton => driver.FindElement(By.XPath("//input[@value='Update']"));
//        public IWebElement EditChooseLevelOption => driver.FindElement(By.XPath("//*[@value='\" + newLevel + \"']"));
//        public IWebElement LastDeleteIcon => driver.FindElement(By.XPath("//div[@data-tab='second']//table/tbody[last()]//i[@class='remove icon']"));

//        public IList<IWebElement> SkillsRows => driver.FindElements(By.XPath("//div[@data-tab='second']//table/tbody"));


//        //Methods
//        public void Click_SkillsTab()
//        {
//            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
//            ProfileTab.Click();

//            WaitUtils.WaitToBeVisible(driver, "Xpath", "SkillsTab", 10);
//            SkillsTab.Click();

//        }
//        public void CreateSkillsRecord(string Skills, string Level)
//        {
//            // Click on Add New button
//            WaitUtils.WaitToBeVisible(driver, "Xpath", "AddNewButton", 5);
//            AddNewButton.Click();

//            // Enter Skills    
//            SkillsTextbox.Click();
//            SkillsTextbox.SendKeys(Skills);

//            // Select Skills Level from dropdown list
//            WaitUtils.WaitToBeVisible(driver, "Xpath", "chooseLevelDropdown", 5);
//            chooseLevelDropdown.Click();
//            driver.FindElement(By.XPath("//*[@value='" + Level + "']")).Click();

//            // Click on save button
//            WaitUtils.WaitToBeVisible(driver, "Xpath", "AddButton", 5);
//            AddButton.Click();

//        }

//        public void EditSkillsRecord(string oldSkills, string newSkills, string oldLevel, string newLevel)
//        {

//            // click edit pencil icon for the existing record
//            WaitUtils.WaitToBeVisible(driver, "Xpath", "EditPencilIcon", 5);
//            EditPencilIcon.Click();

//            if (newSkills.Length > 0)
//            {
//                EditSkillsTextbox.Clear();
//                EditSkillsTextbox.SendKeys(newSkills);
//            }
//            if (newLevel.Length > 0)
//            {
//                WaitUtils.WaitToBeVisible(driver, "Xpath", "EditChooseLevelDropdown", 5);
//                EditChooseLevelDropdown.Click();


//                IWebElement EditChooseLevelOption = driver.FindElement(By.XPath("//*[@value='" + newLevel + "']"));
//                EditChooseLevelOption.Click();

//            }

//            WaitUtils.WaitToBeVisible(driver, "Xpath", "UpdateButton", 5);
//            UpdateButton.Click();

//        }


//        //To Delete Last Skill records
//        public void DeleteLastSkillRecords()
//        {

//            LastDeleteIcon.Click();
//            Thread.Sleep(1000);
//        }

//        //To Delete specific Skill records
//        public void DeletespecificSkillRecords(string newSkill)
//        {

//            for (int i = 1; i <= SkillsRows.Count; i++)
//            {
//                var getSkillName = driver.FindElement(By.XPath($"//div[@data-tab='second']//table/tbody[{i}]/tr/td[1]")).Text;

//                if (getSkillName == newSkill)
//                {

//                    IWebElement specificDeleteIcon = driver.FindElement(By.XPath($"//div[@data-tab='second']//table/tbody[{i}]//i[@class='remove icon']"));
//                    specificDeleteIcon.Click();
//                    Thread.Sleep(1000);
//                }
//            }

//        }

//    }
//}
