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
        
        [Test, Description("Checks that user with correct data can log in")]
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

        [Test, Description("Checks that user with invalid data can`t log in")]
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
