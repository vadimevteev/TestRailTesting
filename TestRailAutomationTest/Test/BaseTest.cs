using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using TestRailAutomationTest.Driver;
using TestRailAutomationTest.Model;
using TestRailAutomationTest.Page;
using TestRailAutomationTest.Service;

namespace TestRailAutomationTest.Test
{

    public abstract class BaseTest
    {
        protected IWebDriver? Driver;
        protected List<User?> Users;
        protected LoginPage LoginPage;
        protected HomePage HomePage;
        protected AddProjectPage AddProjectPage;
        protected OverviewPage OverviewPage;

        [SetUp]
        public void Init()
        {
            Driver = DriverFactory.GetDriver();
            Users = DataReader.GetConfig().Users;
            LoginPage = new LoginPage(Driver);
            HomePage = new HomePage(Driver);
            AddProjectPage = new AddProjectPage(Driver);
            OverviewPage = new OverviewPage(Driver);
        }

        [TearDown]
        public void Close()
        {
            Driver?.Quit();
        }
    }
}
