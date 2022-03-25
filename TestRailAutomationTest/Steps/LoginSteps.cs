using TestRailAutomationTest.Model;
using TestRailAutomationTest.Page;

namespace TestRailAutomationTest.Steps
{
    public class LoginSteps
    {
        private readonly LoginPage _loginPage;

        public LoginSteps(LoginPage loginPage)
        {
            _loginPage = loginPage;
        }

        public void Login(User user)
        {
            _loginPage.OpenStartPage();
            _loginPage
                .FillLoginForm(user)
                .PressFindButton();
        }
    }
}
