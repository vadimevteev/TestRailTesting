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
            var loginPage = new LoginPage(Driver);
            loginPage.OpenStartPage();
            loginPage
                .FillLoginForm(Users.FirstOrDefault()!)
                .PressFindButton();
            var homePage = new HomePage(Driver);
            using (new AssertionScope())
            {
                homePage.IsPageOpened(HomePage.HeaderTitleLocation).Should().BeTrue();
                homePage.GetCurrentUserName().Should().Be(Users.FirstOrDefault()!.Name);
            }
        }

        [Test]
        public void Login_WithInvalidCredentials_ShouldBeFailed()
        {
            var loginPage = new LoginPage(Driver);
            var user = UserCreator.CreateRandomUser();
            loginPage.OpenStartPage();
            string actualErrorMessage = loginPage
                .FillLoginForm(user)
                .PressFindButton()
                .GetErrorMessageText();
            var homePage = new HomePage(Driver);
            using (new AssertionScope())
            {
                homePage.IsPageOpened(HomePage.HeaderTitleLocation).Should().BeFalse();
                actualErrorMessage.Should().Be(ErrorMessages.InvalidPassword);
            }
        }
    }
}
