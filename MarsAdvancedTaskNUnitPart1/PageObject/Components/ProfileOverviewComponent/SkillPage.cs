using MarsAdvancedTaskNUnitPart1.Models.ProfileOverviewModel;
using MarsAdvancedTaskNUnitPart1.Utilities;
using OpenQA.Selenium;

namespace MarsAdvancedTaskNUnitPart1.PageObject.Components.ProfileOverviewComponent
{
    public class SkillPage : CommonDriver
    {
        public SkillPage(IWebDriver driver) : base(driver)
        {
        }

        public SkillPage() : base()
        {
        }

        //Locators
        By ProfileTabLocator => By.XPath("//section//a[@href='/Account/Profile']");
        By SkillsTabLocator => By.XPath("//a[contains(text(),'Skills')]");
        By AddNewButtonLocator => By.XPath("//div[@class='ui teal button']");
        By SkillsTextboxLocator => By.XPath("//*[@placeholder='Add Skill']");
        By chooseLevelDropdownLocator => By.XPath("//*[@class='ui fluid dropdown']");
        By chooseLevelOptionLocator => By.XPath("//*[@value='\" + Level + \"']");
        By AddButtonLocator => By.XPath("//input[@value='Add']");
        By CancelButtonLocator => By.XPath("//input[@value='Cancel']");
        By ToolTipMessageLocator => By.XPath("//*[@class='ns-box-inner']");
        By EditSkillTextboxLocator => By.XPath("//input[@placeholder='Add Skill']");
        By EditChooseLevelDropdownLocator => By.XPath("//*[@class='ui fluid dropdown']");
        By EditPencilIconLocator => By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[4]/tr/td[3]/span[1]/i");
        By UpdateButtonLocator => By.XPath("//input[@value='Update']");
        By EditChooseLevelOptionLocator => By.XPath("//*[@value='\" + newLevel + \"']");
        By LastDeleteIconLocator => By.XPath("//div[@data-tab='second']//table/tbody[last()]//i[@class='remove icon']");
        By SkillRowsLocator => By.XPath("//div[@data-tab='second']//table/tbody");


        // Web Elements
        public IWebElement ProfileTab => driver.FindElement(ProfileTabLocator);
        public IWebElement SkillsTab => driver.FindElement(SkillsTabLocator);
        public IWebElement AddNewButton => driver.FindElement(AddNewButtonLocator);
        public IWebElement SkillsTextbox => driver.FindElement(SkillsTextboxLocator);
        public IWebElement chooseLevelDropdown => driver.FindElement(chooseLevelDropdownLocator);
        public IWebElement chooseLevelOption => driver.FindElement(chooseLevelOptionLocator);
        public IWebElement AddButton => driver.FindElement(AddButtonLocator);
        public IWebElement CancelButton => driver.FindElement(CancelButtonLocator);
        public IWebElement ToolTipMessage => driver.FindElement(ToolTipMessageLocator);
        public IWebElement EditSkillTextbox => driver.FindElement(EditSkillTextboxLocator);
        public IWebElement EditChooseLevelDropdown => driver.FindElement(EditChooseLevelDropdownLocator);
        public IWebElement EditPencilIcon => driver.FindElement(EditPencilIconLocator);
        public IWebElement UpdateButton => driver.FindElement(UpdateButtonLocator);
        public IWebElement EditChooseLevelOption => driver.FindElement(EditChooseLevelOptionLocator);
        public IWebElement LastDeleteIcon => driver.FindElement(LastDeleteIconLocator);
        public IList<IWebElement> SkillRows => driver.FindElements(SkillRowsLocator);


        //Methods
        public void NavigateToSkillsTab()
        {
            WaitUtils.WaitMethod(driver, "ElementIsVisible", ProfileTabLocator, 5);
            ProfileTab.Click();

            WaitUtils.WaitMethod(driver, "ElementIsVisible", SkillsTabLocator, 5);
            SkillsTab.Click();
        }

        public void CreateSkillRecord(SkillModel skillModel)
        {
            By chooseLevelOptionLocator = By.XPath("//*[@value='" + skillModel.Level + "']");

            // Click on Add New button
            WaitUtils.WaitMethod(driver, "ElementIsVisible", AddNewButtonLocator, 5);
            AddNewButton.Click();

            // Enter Skills
            if (!string.IsNullOrEmpty(skillModel.Skill))
            {
                SkillsTextbox.Click();
                SkillsTextbox.SendKeys(skillModel.Skill);
            }

            // Select Skills Level from dropdown list
            if (!string.IsNullOrEmpty(skillModel.Level))
            {
                WaitUtils.WaitMethod(driver, "ElementIsVisible", chooseLevelDropdownLocator, 5);
                chooseLevelDropdown.Click();
                driver.FindElement(chooseLevelOptionLocator).Click();
            }

            // Click on save button
            WaitUtils.WaitMethod(driver, "ElementIsVisible", AddButtonLocator, 5);
            AddButton.Click();

        }

        public void EditSkillRecord(SkillModel skillModel)
        {
            WaitUtils.WaitMethod(driver, "ElementIsVisible", EditSkillTextboxLocator, 5);
            if (!string.IsNullOrEmpty(skillModel.Skill))
            {             
                EditSkillTextbox.Clear();
                EditSkillTextbox.SendKeys(skillModel.Skill);
            }
            if (!string.IsNullOrEmpty(skillModel.Level))
            {
                WaitUtils.WaitMethod(driver, "ElementIsVisible", EditChooseLevelDropdownLocator, 5);
                EditChooseLevelDropdown.Click();


                IWebElement EditChooseLevelOption = driver.FindElement(By.XPath("//*[@value='" + skillModel.Level + "']"));
                EditChooseLevelOption.Click();

            }

            WaitUtils.WaitMethod(driver, "ElementIsVisible", UpdateButtonLocator, 5);
            UpdateButton.Click();

        }

        public bool IsSkillRecordPresent(SkillModel skillModel, int rowNumber = 0)
        {
            bool recordPresent = false;
            string getSkill, getLevel;
            int skillRowPresent;
            By getskillLocator = By.XPath($"//div[@data-tab='second']//table/tbody[{rowNumber}]/tr/td[1]");
            By getLevelLocator = By.XPath($"//div[@data-tab='second']//table/tbody[{rowNumber}]/tr/td[2]");

            if (rowNumber == 0)
            {
                skillRowPresent = GetSkillRow(skillModel);
                if (skillRowPresent > 0)
                {
                    recordPresent = true;
                }
            }
            else
            {
                WaitUtils.WaitMethod(driver, "ElementIsVisible", getskillLocator, 5);
                getSkill = driver.FindElement(getskillLocator).Text;
                WaitUtils.WaitMethod(driver, "ElementIsVisible", getLevelLocator, 5);
                getLevel = driver.FindElement(getLevelLocator).Text;


                ReportLogger.LogInfo($"Retrieved [row {rowNumber}]: Skill: {getSkill}, Level: {getLevel}");
                if (skillModel.Skill.Equals(getSkill) && skillModel.Level.Equals(getLevel))
                {
                    recordPresent = true;
                }
            }

            return recordPresent;
        }

        public int RowCount() => SkillRows.Count;

        public int GetSkillRow(SkillModel skillModel)
        {
            string getSkill, getLevel;

            for (int i = 1; i <= RowCount(); i++)
            {
                try
                {
                    getSkill = driver.FindElement(By.XPath($"//div[@data-tab='second']//table/tbody[{i}]/tr/td[1]")).Text;
                    getLevel = driver.FindElement(By.XPath($"//div[@data-tab='second']//table/tbody[{i}]/tr/td[2]")).Text;

                    if (skillModel.Skill.Equals(getSkill) && skillModel.Level.Equals(getLevel))
                    {
                        ReportLogger.LogInfo($"skill Present at row: {i}");
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


        public void SelectSkillRecord(SkillModel skillModel)
        {

            int rowNumber = GetSkillRow(skillModel);
            By editPencilIconLocator = By.XPath($"//div[@data-tab='second']//table/tbody[{rowNumber}]//i[@class='outline write icon']");
            if (rowNumber > 0)
            {
                WaitUtils.WaitMethod(driver, "ElementIsVisible", editPencilIconLocator, 5);

                var editButton = driver.FindElement(editPencilIconLocator);
                editButton.Click();
            }

        }


        //To Delete Last Skill record
        public void DeleteLastSkillRecord()
        {
            WaitUtils.WaitMethod(driver, "ElementIsVisible", LastDeleteIconLocator, 10);
            LastDeleteIcon.Click();
        }

        
        public void ClearSkill()
        {

            if (SkillRows != null && SkillRows.Count > 0)
            {

                int rowCount = SkillRows.Count;

                for (int i = 1; i <= rowCount; i++)
                {
                    DeleteLastSkillRecord();
                    Thread.Sleep(1000);
                }
            }


        }

    }
}
