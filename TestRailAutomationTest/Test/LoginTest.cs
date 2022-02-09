using System.Linq;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using TestRailAutomationTest.Page;
using TestRailAutomationTest.Page.Constants;
using TestRailAutomationTest.Service;

namespace TestRailAutomationTest.Test
{
    public class LoginPageTest : BaseTest
    {
        
        [Test]
        public void Login_WithValidCredentials_ShouldBeSuccessful()
        {
            LoginPage.OpenStartPage();
            LoginPage
                .FillLoginForm(Users.FirstOrDefault()!)
                .PressFindButton();
            using (new AssertionScope())
            {
                HomePage.IsPageOpened(HomePage.HeaderTitleLocation).Should().BeTrue();
                HomePage.GetCurrentUserName().Should().Be(Users.FirstOrDefault()!.Name);
            }
        }

        [Test]
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
                HomePage.IsPageOpened(HomePage.HeaderTitleLocation).Should().BeFalse();
                actualErrorMessage.Should().Be(ErrorMessages.InvalidPassword);
            }
        }
    }
}
