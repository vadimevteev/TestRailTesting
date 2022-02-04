using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using TestRailAutomationTest.Driver;
using TestRailAutomationTest.Page;
using TestRailAutomationTest.Service;

namespace TestRailAutomationTest.Test;

public class LoginPageTest
{
    private IWebDriver driver;

    [SetUp]
    public void Init()
    {
        driver = DriverFactory.GetDriver();
    }
    
    [Test]
    public void LoginTest()
    {
        var user = UserCreator.CreateUser();
        new LoginPage(driver)
            .OpenPage()
            .FillLoginForm(user)
            .PressFindButton();
        var homePage = new HomePage(driver);
        homePage.IsPageOpened().Should().BeTrue();
    }

    [TearDown]
    public void Close()
    {
         driver.Quit();
    }
}
