using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using TestRailAutomationTest.Driver;
using TestRailAutomationTest.Model;
using TestRailAutomationTest.Service;

namespace TestRailAutomationTest.Test;

public abstract class BaseTest
{
    protected IWebDriver driver;
    protected List<User> users;

    [SetUp]
    public void Init()
    {
        driver = DriverFactory.GetDriver();
        users = DataReader.GetConfig().Users;
    }

    [TearDown]
    public void Close()
    {
        driver.Quit();
    }
}
