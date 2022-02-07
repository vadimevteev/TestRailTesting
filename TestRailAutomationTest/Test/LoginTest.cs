using System.Linq;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using TestRailAutomationTest.Page;

namespace TestRailAutomationTest.Test;

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
            homePage.GetCurrentUserName().Should().Match(Users.FirstOrDefault()!.Name);
        }
    }
}
