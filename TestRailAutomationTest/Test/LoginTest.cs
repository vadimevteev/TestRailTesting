using System;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using TestRailAutomationTest.Driver;
using TestRailAutomationTest.Page;
using TestRailAutomationTest.Service;

namespace TestRailAutomationTest.Test;

public class LoginPageTest : BaseTest
{
    [Test]
    public void testIsOneCanLogIn()
    {
        new LoginPage(driver)
            .OpenPage()
            .FillLoginForm(users[0])
            .PressFindButton();
        var homePage = new HomePage(driver);
        homePage.IsPageOpened(HomePage.HeaderTitleLocation).Should().BeTrue();
    }
}
