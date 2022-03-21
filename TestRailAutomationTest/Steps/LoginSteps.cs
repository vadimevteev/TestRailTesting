using System.Collections.Generic;
using System.Linq;
using TestRailAutomationTest.Model;
using TestRailAutomationTest.Page;

namespace TestRailAutomationTest.Steps
{
    public static class LoginSteps
    {
        public static void Login(LoginPage loginPage, IEnumerable<User?> users)
        {
            loginPage.OpenStartPage();
            loginPage
                .FillLoginForm(users.FirstOrDefault()!)
                .PressFindButton();
        }
    }
}
