using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestRailAutomationTest.Driver;
using TestRailAutomationTest.Service;

namespace TestRailAutomationTest.Test;

public class HomePageTest
{
    private IWebDriver driver;

    [SetUp]
    public void Init()
    {
        driver = DriverFactory.GetDriver();
    }
    
    [Test]
    public void Test()
    {
        string homePageUrl = DataReader.GetConfig().HomePageUrl;
        driver.Url = homePageUrl;
        Assert.True(driver.Url.Contains(homePageUrl));
    }

    [TearDown]
    public void Close()
    {
         driver.Quit();
    }
}
