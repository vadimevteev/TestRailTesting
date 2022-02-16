using System.Linq;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using TestRailAutomationTest.Page;
using TestRailAutomationTest.Page.Constants;
using TestRailAutomationTest.Service;

namespace TestRailAutomationTest.Test
{
    public class LoginTest : BaseTest
    {
        
        [Test, Description("Login with valid credentials, " +
                           "home page should be opened with correct user account")]
        public void Login_WithValidCredentials_ShouldBeSuccessful()
        {
            LoginPage.OpenStartPage();
            LoginPage
                .FillLoginForm(Users.FirstOrDefault()!)
                .PressFindButton();
            using (new AssertionScope())
            {
                HomePage.IsElementExistOnPage(HomePage.HeaderTitleLocation).Should().BeTrue();
                HomePage.GetCurrentUserName().Should().Be(Users.FirstOrDefault()!.Name);
            }
        }

        [Test, Description("Login with invalid credentials," 
                           + "home page shouldn`t be opened and error message should be shown")]
        public void Login_WithInvalidCredentials_ShouldBeFailed()
        {
            var user = UserCreator.CreateRandom();
            LoginPage.OpenStartPage();
            var actualErrorMessage = LoginPage
                .FillLoginForm(user)
                .PressFindButton()
                .GetErrorMessageText();
            using (new AssertionScope())
            {
                HomePage.IsElementExistOnPage(HomePage.HeaderTitleLocation).Should().BeFalse();
                actualErrorMessage.Should().Be(ErrorMessages.InvalidPassword);
            }
        }
    }
}
