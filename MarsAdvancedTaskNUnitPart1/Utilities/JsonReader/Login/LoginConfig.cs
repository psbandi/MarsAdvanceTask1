using MarsAdvancedTaskNUnitPart1.Models.LoginModel;
using System.Text.Json;

namespace MarsAdvancedTaskNUnitPart1.Utilities.JsonReader.Login
{
    public class LoginConfig
    { 
        public static List<LoginModel> LoadConfig()
        {
            // Load JSON data from the file
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", "Login", "LoginTestData.json");
            string jsonString = File.ReadAllText(jsonFilePath);

            //deserialization of data
            return JsonSerializer.Deserialize<List<LoginModel>>(jsonString);       

        }
    }
}
