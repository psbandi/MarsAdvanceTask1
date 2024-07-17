using System.Text.Json;
using MarsAdvancedTaskNUnitPart1.Models.ProfileOverviewModel;

namespace MarsAdvancedTaskNUnitPart1.Utilities.JsonReader.ProfileOverviewComponent
{
    public class SkillConfig
    {
        public static List<SkillModel> LoadConfig(string fileName)
        {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", "ProfileOverviewComponent", "Skills", fileName);
            string jsonString = File.ReadAllText(jsonFilePath);
            return JsonSerializer.Deserialize<List<SkillModel>>(jsonString);
        }

        public static List<SkillModel> LoadCreateSkillWithValidData()
        {
            return LoadConfig("CreateSkillWithValidData.json");
        }

        public static List<SkillModel> LoadEditSkillWithValidData()
        {
            return LoadConfig("EditSkillWithValidData.json");
        }

        public static List<SkillModel> LoadDeleteSkill()
        {
            return LoadConfig("DeleteSkill.json");
        }

        public static List<SkillModel> LoadCreateSkillWithNullData()
        {
            return LoadConfig("CreateSkillWithNullData.json");
        }

        public static List<SkillModel> LoadCreateSkillWithDuplicateData()
        {
            return LoadConfig("CreateSkillWithDuplicateData.json");
        }

        public static List<SkillModel> LoadEditSkillWithNullData()
        {
            return LoadConfig("EditSkillWithNullData.json");
        }

        public static List<SkillModel> LoadEditSkillWithDuplicateData()
        {
            return LoadConfig("EditSkillWithDuplicateData.json");
        }
    }
}
