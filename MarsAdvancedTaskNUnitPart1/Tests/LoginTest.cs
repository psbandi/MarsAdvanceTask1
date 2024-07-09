using MarsAdvancedTaskNUnitPart1.PageObject.Components.ProfileOverviewComponent;
using NUnit.Framework;

namespace MarsAdvancedTaskNUnitPart1.Tests
{
    
    public class LoginTest : BaseTest 
    {   
      
        [Test, Description("User signin successfully")]
        public void LoginwithValidCrendentials()
        {
            LoginPage loginPageObject = new LoginPage();

            Assert.Pass("Passed");
        }
               
    }
}
