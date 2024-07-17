using MarsAdvancedTaskNUnitPart1.Assertions;
using MarsAdvancedTaskNUnitPart1.Models.ProfileOverviewModel;
using MarsAdvancedTaskNUnitPart1.Utilities.JsonReader.ProfileOverviewComponent;
using NUnit.Framework;

namespace MarsAdvancedTaskNUnitPart1.Tests.ProfileOverviewComponent
{
    [TestFixture]
    [Parallelizable]
    public class LanguageTest : BaseTest
    {
        [SetUp]
        public void SetUpLanguage()
        {
            languagePageObject.NavigateToLanguageTab();
            languagePageObject.ClearLanguage();
           
        }

        [Test, Order(1), Description("This test create 4 Language record with valid data")]
        public void TestCreateLanguageWithVaildData()
        {
            // Load test data for creating Language
            List<LanguageModel> testData = LanguageConfig.LoadCreateLanguageWithValidData();

            foreach (var language in testData)
            {
                languagePageObject.CreateLanguageRecord(language);
                Thread.Sleep(2000);
                AssertionHelpers.AssertToolTipMessage(languagePageObject, language.AssertionMessage);
                bool recordPresent = languagePageObject.IsLanguageRecordPresent(language);
                Assert.That(recordPresent, Is.True);                                           
            }
            bool isAddNewButtonDisplayed = languagePageObject.IsAddNewButtonDisplayed();
            Assert.That(isAddNewButtonDisplayed, Is.False);

            foreach (var language in testData)
            {
                languagePageObject.DeleteLastLanguageRecords();
            }
        }
                

        [Test, Order(2), Description("This test edits Language records with valid data")]
        public void TestEditLanguageWithValidData()
        {
            List<LanguageModel> createData = LanguageConfig.LoadCreateLanguageWithValidData();
            List<LanguageModel> editData = LanguageConfig.LoadEditLanguageWithValidData();

            foreach (var initialLanguage in createData)
            {

                languagePageObject.CreateLanguageRecord(initialLanguage);
                Thread.Sleep(2000);
                AssertionHelpers.AssertToolTipMessage(languagePageObject, initialLanguage.AssertionMessage);
            }

            foreach (var Language in editData)
            {
                LanguageModel originalLanguage = createData.First(l => l.Language == Language.OriginalLanguage);

                if (originalLanguage != null)
                {
                    languagePageObject.SelectLanguageRecord(originalLanguage);
                    languagePageObject.EditLanguageRecord(Language);
                    Thread.Sleep(2000);
                    AssertionHelpers.AssertToolTipMessage(languagePageObject, Language.AssertionMessage);

                    bool recordPresent = languagePageObject.IsLanguageRecordPresent(Language);
                    Assert.That(recordPresent, Is.True);
                }
            }
            foreach (var Language in editData)
            {
                languagePageObject.DeleteLastLanguageRecords();
                Thread.Sleep(1000);
            }
        }

        [Test, Order(3), Description("This test deletes Language records")]
        public void TestDeleteLanguageRecords()
        {
            List<LanguageModel> testData = LanguageConfig.LoadDeleteLanguage();

            foreach (var Language in testData)
            {
                languagePageObject.CreateLanguageRecord(Language);
                bool recordPresentBeforeDeletion = languagePageObject.IsLanguageRecordPresent(Language);

                if (recordPresentBeforeDeletion)
                {
                    languagePageObject.DeleteLastLanguageRecords();
                    Thread.Sleep(1000);
                    AssertionHelpers.AssertToolTipMessage(languagePageObject, Language.AssertionMessage);
                    bool recordPresent = languagePageObject.IsLanguageRecordPresent(Language);
                    Assert.That(recordPresent, Is.False);
                }
            }
        }


        [Test, Order(4), Description("This test add Language record with null data")]
        public void TestCreateLanguageRecordWithNullData()
        {
            List<LanguageModel> testData = LanguageConfig.LoadCreateLanguageWithNullData();

            foreach (var Language in testData)
            {
                languagePageObject.CreateLanguageRecord(Language);
                bool recordPresent = languagePageObject.IsLanguageRecordPresent(Language);
                Assert.That(recordPresent, Is.False);
                languagePageObject.CancelButton.Click();
            }
        }


        [Test, Order(5), Description("This test add Language record with Duplicate data")]
        public void TestCreateLanguageRecordWithDuplicateData()
        {
            List<LanguageModel> createData = LanguageConfig.LoadCreateLanguageWithValidData();
            List<LanguageModel> testData = LanguageConfig.LoadCreateLanguageWithDuplicateData();

            LanguageModel initialLanguage = createData.First();
            LanguageModel Language = testData.First();

            languagePageObject.CreateLanguageRecord(initialLanguage);
            Thread.Sleep(2000);
            AssertionHelpers.AssertToolTipMessage(languagePageObject, initialLanguage.AssertionMessage);            

            languagePageObject.CreateLanguageRecord(Language);
            Thread.Sleep(2000);
            AssertionHelpers.AssertToolTipMessage(languagePageObject, Language.AssertionMessage);                       
            int rowCount = languagePageObject.RowCount();
            Assert.That(languagePageObject.RowCount(), Is.EqualTo(rowCount));
            languagePageObject.CancelButton.Click();

            languagePageObject.DeleteLastLanguageRecords();
        }


        [Test, Order(6), Description("This test edits Language record with duplicate data")]
        public void TestEditLanguageRecordWithDuplicateData()
        {
            List<LanguageModel> createData = LanguageConfig.LoadCreateLanguageWithValidData();
            List<LanguageModel> editData = LanguageConfig.LoadEditLanguageWithDuplicateData();

            LanguageModel initialLanguage = createData.First();
            LanguageModel editLanguage = editData.First();

            languagePageObject.CreateLanguageRecord(initialLanguage);
            Thread.Sleep(1000);
            AssertionHelpers.AssertToolTipMessage(languagePageObject, initialLanguage.AssertionMessage);

            languagePageObject.SelectLanguageRecord(initialLanguage);
            languagePageObject.EditLanguageRecord(editLanguage);
            Thread.Sleep(1000);
            AssertionHelpers.AssertToolTipMessage(languagePageObject, editLanguage.AssertionMessage);

            languagePageObject.CancelButton.Click();

            int rowCount = languagePageObject.RowCount();
            Assert.That(languagePageObject.RowCount(), Is.EqualTo(rowCount));

            languagePageObject.DeleteLastLanguageRecords();

        }


        [Test, Order(7), Description("This test edits Language record with null data")]
        public void TestEditLanguageRecordWithNullData()
        {
            List<LanguageModel> createData = LanguageConfig.LoadCreateLanguageWithValidData();
            List<LanguageModel> editData = LanguageConfig.LoadEditLanguageWithNullData();

            LanguageModel initialLanguage = createData.First();
            LanguageModel editLanguage = editData.First();

            languagePageObject.CreateLanguageRecord(initialLanguage);
            Thread.Sleep(1000);
            AssertionHelpers.AssertToolTipMessage(languagePageObject, initialLanguage.AssertionMessage);

            languagePageObject.SelectLanguageRecord(initialLanguage);
            languagePageObject.EditLanguageRecord(editLanguage);
            Thread.Sleep(1000);
            AssertionHelpers.AssertToolTipMessage(languagePageObject, editLanguage.AssertionMessage);

            languagePageObject.CancelButton.Click();

            bool recordPresent = languagePageObject.IsLanguageRecordPresent(editLanguage);
            Assert.That(recordPresent, Is.False);

            languagePageObject.DeleteLastLanguageRecords();

        }

    }
}
