using MarsAdvancedTaskNUnitPart1.Assertions;
using MarsAdvancedTaskNUnitPart1.Models.ProfileOverviewModel;
using MarsAdvancedTaskNUnitPart1.Utilities.JsonReader.ProfileOverviewComponent;
using NUnit.Framework;


namespace MarsAdvancedTaskNUnitPart1.Tests.ProfileOverviewComponent
{
    [TestFixture]
    [Parallelizable]
    public class SkillTest : BaseTest
    {
        [SetUp]
        public void SetUpSkill()
        {
            skillPageObject.NavigateToSkillsTab();
            skillPageObject.ClearSkill();
            Thread.Sleep(1000);
        }

        [Test, Order(1), Description("This test create a new skill record with valid data")]
        public void TestCreateSkillWithVaildData()
        {
            // Load test data for creating skill
            List<SkillModel> testData = SkillConfig.LoadCreateSkillWithValidData();

            foreach (var skill in testData)
            {
                skillPageObject.CreateSkillRecord(skill);
                Thread.Sleep(2000);
                AssertionHelpers.AssertToolTipMessage(skillPageObject, skill.AssertionMessage);
                bool recordPresent = skillPageObject.IsSkillRecordPresent(skill);
                Assert.That(recordPresent, Is.True);
                skillPageObject.DeleteLastSkillRecord();
            }
        }


        [Test, Order(2), Description("This test edits skill records with valid data")]
        public void TestEditSkillWithValidData()
        {
            List<SkillModel> createData = SkillConfig.LoadCreateSkillWithValidData();
            List<SkillModel> editData = SkillConfig.LoadEditSkillWithValidData();

            foreach (var initialSkill in createData)
            {

                skillPageObject.CreateSkillRecord(initialSkill);
                Thread.Sleep(2000);
                AssertionHelpers.AssertToolTipMessage(skillPageObject, initialSkill.AssertionMessage);
            }

            foreach (var skill in editData)
            {
                SkillModel originalSkill = createData.First(s => s.Skill == skill.OriginalSkill);

                if (originalSkill != null)
                {
                    skillPageObject.SelectSkillRecord(originalSkill);
                    skillPageObject.EditSkillRecord(skill);
                    Thread.Sleep(2000);
                    AssertionHelpers.AssertToolTipMessage(skillPageObject, skill.AssertionMessage);

                    bool recordPresent = skillPageObject.IsSkillRecordPresent(skill);
                    Assert.That(recordPresent, Is.True);
                }
            }
            foreach (var skill in editData)
            {
                skillPageObject.DeleteLastSkillRecord();
                Thread.Sleep(1000);
            }
        }

        [Test, Order(3), Description("This test deletes skill records")]
        public void TestDeleteSkillRecords()
        {
            List<SkillModel> testData = SkillConfig.LoadDeleteSkill();

            foreach (var skill in testData)
            {
                skillPageObject.CreateSkillRecord(skill);
                bool recordPresentBeforeDeletion = skillPageObject.IsSkillRecordPresent(skill);

                if (recordPresentBeforeDeletion)
                {
                    skillPageObject.DeleteLastSkillRecord();
                    Thread.Sleep(1000);
                    AssertionHelpers.AssertToolTipMessage(skillPageObject, skill.AssertionMessage);
                    bool recordPresent = skillPageObject.IsSkillRecordPresent(skill);
                    Assert.That(recordPresent, Is.False);
                }
            }
        }


        [Test, Order(4), Description("This test add skill record with null data")]
        public void TestCreateSkillRecordWithNullData()
        {
            List<SkillModel> testData = SkillConfig.LoadCreateSkillWithNullData();

            foreach (var skill in testData)
            {
                skillPageObject.CreateSkillRecord(skill);
                bool recordPresent = skillPageObject.IsSkillRecordPresent(skill);
                Assert.That(recordPresent, Is.False);
                skillPageObject.CancelButton.Click();
            }
        }


        [Test, Order(5), Description("This test add skill record with Duplicate data")]
        public void TestCreateSkillRecordWithDuplicateData()
        {
            List<SkillModel> createData = SkillConfig.LoadCreateSkillWithValidData();
            List<SkillModel> testData = SkillConfig.LoadCreateSkillWithDuplicateData();

            SkillModel initialSkill = createData.First();
            SkillModel skill = testData.First();

            skillPageObject.CreateSkillRecord(initialSkill);
            Thread.Sleep(2000);
            AssertionHelpers.AssertToolTipMessage(skillPageObject, initialSkill.AssertionMessage);

            skillPageObject.CreateSkillRecord(skill);
            Thread.Sleep(2000);
            AssertionHelpers.AssertToolTipMessage(skillPageObject, skill.AssertionMessage);
            int rowCount = skillPageObject.RowCount();
            Assert.That(skillPageObject.RowCount(), Is.EqualTo(rowCount));
            skillPageObject.CancelButton.Click();

            skillPageObject.DeleteLastSkillRecord();
        }


        [Test, Order(6), Description("This test edits skill record with duplicate data")]
        public void TestEditSkillRecordWithDuplicateData()
        {
            List<SkillModel> createData = SkillConfig.LoadCreateSkillWithValidData();
            List<SkillModel> editData = SkillConfig.LoadEditSkillWithDuplicateData();

            SkillModel initialSkill = createData.First();
            SkillModel editSkill = editData.First();

            skillPageObject.CreateSkillRecord(initialSkill);
            Thread.Sleep(1000);
            AssertionHelpers.AssertToolTipMessage(skillPageObject, initialSkill.AssertionMessage);

            skillPageObject.SelectSkillRecord(initialSkill);
            skillPageObject.EditSkillRecord(editSkill);
            Thread.Sleep(1000);
            AssertionHelpers.AssertToolTipMessage(skillPageObject, editSkill.AssertionMessage);

            skillPageObject.CancelButton.Click();

            int rowCount = skillPageObject.RowCount();
            Assert.That(skillPageObject.RowCount(), Is.EqualTo(rowCount));

            skillPageObject.DeleteLastSkillRecord();

        }


        [Test, Order(7), Description("This test edits skill record with null data")]
        public void TestEditSkillRecordWithNullData()
        {
            List<SkillModel> createData = SkillConfig.LoadCreateSkillWithValidData();
            List<SkillModel> editData = SkillConfig.LoadEditSkillWithNullData();

            SkillModel initialSkill = createData.First();
            SkillModel editSkill = editData.First();

            skillPageObject.CreateSkillRecord(initialSkill);
            Thread.Sleep(1000);
            AssertionHelpers.AssertToolTipMessage(skillPageObject, initialSkill.AssertionMessage);

            skillPageObject.SelectSkillRecord(initialSkill);
            skillPageObject.EditSkillRecord(editSkill);
            Thread.Sleep(1000);
            AssertionHelpers.AssertToolTipMessage(skillPageObject, editSkill.AssertionMessage);

            skillPageObject.CancelButton.Click();

            bool recordPresent = skillPageObject.IsSkillRecordPresent(editSkill);
            Assert.That(recordPresent, Is.False);

            skillPageObject.DeleteLastSkillRecord();

        }

    }
}
