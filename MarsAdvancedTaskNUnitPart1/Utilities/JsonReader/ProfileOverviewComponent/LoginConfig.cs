﻿using System.Text.Json;

namespace MarsAdvancedTaskNUnitPart1.Utilities.JsonReader.ProfileOverviewComponent
{
    public class LoginConfig
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public static List<LoginConfig> LoadConfig()
        {
            // Load JSON data from the file
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", "Login", "LoginTestData.json");
            string jsonString = File.ReadAllText(jsonFilePath);

            //deserialization of data
            List<LoginConfig> loginConfig = JsonSerializer.Deserialize<List<LoginConfig>>(jsonString);

            return loginConfig;

        }
    }
}
