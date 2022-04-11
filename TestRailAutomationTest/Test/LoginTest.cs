using System.Linq;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using TestRailAutomationTest.Page;
using TestRailAutomationTest.Page.Constants;
using TestRailAutomationTest.Service;
using TestRailAutomationTest.Steps;

namespace TestRailAutomationTest.Test
{
    public class LoginTest : BaseTest
    {
        private LoginSteps? _loginSteps;

        [SetUp]
        public void SetUp()
        {
            _loginSteps = new LoginSteps(LoginPage);
        }
        
        [Test, Description("Login with valid credentials should be successful, " +
                           "home page should be opened with correct user account")]
        public void Login_WithValidCredentials_ShouldBeSuccessful()
        {
            _loginSteps!.Login(Users.FirstOrDefault()!);
            
            using (new AssertionScope())
            {
                HomePage.IsElementExistOnPage(HomePage.HeaderTitleLocation).Should().BeTrue();
                HomePage.GetCurrentUserName().Should().Be(Users.FirstOrDefault()!.Name);
            }
        }

        [Test, Description("Login with invalid credentials should be failed," 
                           + "home page shouldn`t be opened and error message should be shown")]
        public void Login_WithInvalidCredentials_ShouldBeFailed()
        {
            var user = UserCreator.CreateRandom();
            
            _loginSteps!.Login(user);
            var actualErrorMessage = LoginPage.GetErrorMessageText();
            using (new AssertionScope())
            {
                HomePage.IsElementExistOnPage(HomePage.HeaderTitleLocation).Should().BeFalse();
                actualErrorMessage.Should().Be(ErrorMessages.InvalidPassword);
            }
        }
    }
}
