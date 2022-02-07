using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using TestRailAutomationTest.Driver;
using TestRailAutomationTest.Model;
using TestRailAutomationTest.Service;

namespace TestRailAutomationTest.Test;

public abstract class BaseTest
{
    protected IWebDriver? Driver;
    protected List<User?> Users;

    [SetUp]
    public void Init()
    {
        Driver = DriverFactory.GetDriver();
        Users = DataReader.GetConfig().Users;
    }

    [TearDown]
    public void Close()
    {
        Driver?.Quit();
    }
}
