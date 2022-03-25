using TestRailAutomationTest.Model;
using TestRailAutomationTest.Page;

namespace TestRailAutomationTest.Steps
{
    public class LoginSteps
    {
        private readonly LoginPage _loginPage;
        private readonly User _user;
        
        public LoginSteps(LoginPage loginPage, User user)
        {
            _loginPage = loginPage;
            _user = user;
        }

        public void Login()
        {
            _loginPage.OpenStartPage();
            _loginPage
                .FillLoginForm(_user)
                .PressFindButton();
        }
    }
}
