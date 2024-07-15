//using MarsAdvancedTaskNUnitPart1.Assertions;
//using MarsAdvancedTaskNUnitPart1.Utilities.JsonReader.ProfileOverviewComponent;
//using NUnit.Framework;


//namespace MarsAdvancedTaskNUnitPart1.Tests.ProfileOverviewComponent
//{
//    [TestFixture]
//    [Parallelizable]
//    public class SkillTest : BaseTest
//    {
//        [SetUp]
//        public void SetUpEducation()
//        {
//            educationPageObject.NavigateToEducationTab();
//            educationPageObject.ClearEducation();
//            Thread.Sleep(1000);
//        }

//        [Test, Order(1), Description("This test create a new Education record with valid data")]
//        public void TestCreateEducationWithValidData()
//        {
//            List<EducationConfig> testData = EducationConfig.LoadCreateEducationWithValidData();
//            foreach (var education in testData)
//            {
//                educationPageObject.CreateEducationRecord(education);
//                AssertionHelpers.AssertToolTipMessage(educationPageObject, education.AssertionMessage);
//                bool recordPresent = educationPageObject.IsEducationRecordPresent(education);
//                Assert.That(recordPresent, Is.True);
//                educationPageObject.DeleteLastEducationRecords();
//            }
//        }

//        [Test, Order(2), Description("This test edits education records with valid data")]
//        public void TestEditEducationRecords()
//        {
//            List<EducationConfig> createData = EducationConfig.LoadCreateEducationWithValidData();
//            List<EducationConfig> editData = EducationConfig.LoadEditEducationWithValidData();

//            foreach (var initialeducation in createData)
//            {

//                educationPageObject.CreateEducationRecord(initialeducation);
//                AssertionHelpers.AssertToolTipMessage(educationPageObject, initialeducation.AssertionMessage);
//            }

//            foreach (var education in editData)
//            {
//                EducationConfig originalEducation = createData.FirstOrDefault(e => e.University == education.OriginalEducation);

//                if (originalEducation != null)
//                {
//                    educationPageObject.SelectEducationRecord(originalEducation);
//                    educationPageObject.EditEducationRecord(education);
//                    AssertionHelpers.AssertToolTipMessage(educationPageObject, education.AssertionMessage);
//                    Thread.Sleep(1000);
//                    bool recordPresent = educationPageObject.IsEducationRecordPresent(education);
//                    Assert.That(recordPresent, Is.True);
//                }
//            }
//            foreach (var education in editData)
//            {
//                educationPageObject.DeleteLastEducationRecords();
//            }
//        }


//        [Test, Order(3), Description("This test deletes education records")]
//        public void TestDeleteEducationRecords()
//        {
//            List<EducationConfig> testData = EducationConfig.LoadDeleteEducation();

//            foreach (var education in testData)
//            {
//                educationPageObject.CreateEducationRecord(education);
//                bool recordPresentBeforeDeletion = educationPageObject.IsEducationRecordPresent(education);

//                if (recordPresentBeforeDeletion)
//                {
//                    educationPageObject.DeleteLastEducationRecords();
//                    AssertionHelpers.AssertToolTipMessage(educationPageObject, education.AssertionMessage);
//                    bool recordPresent = educationPageObject.IsEducationRecordPresent(education);
//                    Assert.That(recordPresent, Is.False);
//                }
//            }
//        }


//        [Test, Order(4), Description("This test add education record with null data")]
//        public void TestCreateEducationRecordWithNullData()
//        {
//            List<EducationConfig> testData = EducationConfig.LoadCreateEducationWithNullData();

//            foreach (var education in testData)
//            {
//                educationPageObject.CreateEducationRecord(education);
//                bool recordPresent = educationPageObject.IsEducationRecordPresent(education);
//                Assert.That(recordPresent, Is.False);
//                educationPageObject.CancelButton.Click();
//                Thread.Sleep(1000);
//            }
//        }


//        [Test, Order(5), Description("This test add education record with Duplicate data")]
//        public void TestCreateEducationRecordWithDuplicateData()
//        {
//            List<EducationConfig> createData = EducationConfig.LoadCreateEducationWithValidData();
//            List<EducationConfig> testData = EducationConfig.LoadCreateEducationWithDuplicateData();

//            EducationConfig initialeducation = createData.First();
//            EducationConfig education = testData.First();

//            educationPageObject.CreateEducationRecord(initialeducation);
//            AssertionHelpers.AssertToolTipMessage(educationPageObject, initialeducation.AssertionMessage);

//            educationPageObject.CreateEducationRecord(education);
//            AssertionHelpers.AssertToolTipMessage(educationPageObject, education.AssertionMessage);
//            educationPageObject.CancelButton.Click();
//            Thread.Sleep(1000);
//            int rowCount = educationPageObject.RowCount();
//            Assert.That(educationPageObject.RowCount(), Is.EqualTo(rowCount));

//            educationPageObject.DeleteLastEducationRecords();

//        }


//        [Test, Order(6), Description("This test edits education record with duplicate data")]
//        public void TestEditEducationRecordWithDuplicateData()
//        {
//            List<EducationConfig> createData = EducationConfig.LoadCreateEducationWithValidData();
//            List<EducationConfig> editData = EducationConfig.LoadEditEducationWithDuplicateData();

//            EducationConfig initialeducation = createData.First();
//            EducationConfig editEducation = editData.First();

//            educationPageObject.CreateEducationRecord(initialeducation);
//            AssertionHelpers.AssertToolTipMessage(educationPageObject, initialeducation.AssertionMessage);

//            educationPageObject.SelectEducationRecord(initialeducation);
//            educationPageObject.EditEducationRecord(editEducation);
//            AssertionHelpers.AssertToolTipMessage(educationPageObject, editEducation.AssertionMessage);
//            Thread.Sleep(3000);
//            educationPageObject.CancelButton.Click();
//            Thread.Sleep(1000);
//            int rowCount = educationPageObject.RowCount();
//            Assert.That(educationPageObject.RowCount(), Is.EqualTo(rowCount));

//            educationPageObject.DeleteLastEducationRecords();

//        }


//        [Test, Order(7), Description("This test edits education record with null data")]
//        public void TestEditEducationRecordWithNullData()
//        {
//            List<EducationConfig> createData = EducationConfig.LoadCreateEducationWithValidData();
//            List<EducationConfig> editData = EducationConfig.LoadEditEducationWithNullData();

//            EducationConfig initialeducation = createData.First();
//            EducationConfig editEducation = editData.First();

//            educationPageObject.CreateEducationRecord(initialeducation);
//            AssertionHelpers.AssertToolTipMessage(educationPageObject, initialeducation.AssertionMessage);


//            educationPageObject.SelectEducationRecord(initialeducation);
//            educationPageObject.EditEducationRecord(editEducation);
//            AssertionHelpers.AssertToolTipMessage(educationPageObject, editEducation.AssertionMessage);

//            //educationPageObject.CancelButton.Click();
//            //Thread.Sleep(1000);
//            bool recordPresent = educationPageObject.IsEducationRecordPresent(editEducation);
//            Assert.That(recordPresent, Is.False);

//            Console.WriteLine($"Record presence after edit: {recordPresent}");

//            educationPageObject.DeleteLastEducationRecords();

//        }

//    }
//}
