using System.Text.Json;
using MarsAdvancedTaskNUnitPart1.Models.ProfileOverviewModel;


namespace MarsAdvancedTaskNUnitPart1.Utilities.JsonReader.ProfileOverviewComponent
{
    public class LanguageConfig
    {        
        public static List<LanguageModel> LoadConfig(string fileName)
        {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", "ProfileOverviewComponent", "Language", fileName);
            string jsonString = File.ReadAllText(jsonFilePath);
            return JsonSerializer.Deserialize<List<LanguageModel>>(jsonString);
        }

        public static List<LanguageModel> LoadCreateLanguageWithValidData()
        {
            return LoadConfig("CreateLanguageWithValidData.json");
        }

        public static List<LanguageModel> LoadEditLanguageWithValidData()
        {
            return LoadConfig("EditLanguageWithValidData.json");
        }

        public static List<LanguageModel> LoadDeleteLanguage()
        {
            return LoadConfig("DeleteLanguage.json");
        }

        public static List<LanguageModel> LoadCreateLanguageWithNullData()
        {
            return LoadConfig("CreateLanguageWithNullData.json");
        }

        public static List<LanguageModel> LoadCreateLanguageWithDuplicateData()
        {
            return LoadConfig("CreateLanguageWithDuplicateData.json");
        }

        public static List<LanguageModel> LoadEditLanguageWithNullData()
        {
            return LoadConfig("EditLanguageWithNullData.json");
        }

        public static List<LanguageModel> LoadEditLanguageWithDuplicateData()
        {
            return LoadConfig("EditLanguageWithDuplicateData.json");
        }
    }
}
