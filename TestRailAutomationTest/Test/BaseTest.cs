using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using TestRailAutomationTest.Driver;
using TestRailAutomationTest.Model;
using TestRailAutomationTest.Page;
using TestRailAutomationTest.Page.Project;
using TestRailAutomationTest.Service;

namespace TestRailAutomationTest.Test
{

    public abstract class BaseTest
    {
        public static readonly string LoginPageUrl = DataReader.GetConfig().AppUrl;
        protected IWebDriver? Driver;
        protected List<User?> Users;
        protected LoginPage LoginPage;
        protected HomePage HomePage;
        protected AddProjectPage AddProjectPage;
        protected ProjectsMenuPage ProjectsMenuPage;
        protected OverviewPage OverviewPage;
        protected TestCasesPage TestCasesPage;
        protected AddTestCasePage AddTestCasePage;

        [SetUp]
        public void Init()
        {
            Driver = DriverFactory.GetDriver();
            Users = DataReader.GetConfig().Users;
            LoginPage = new LoginPage(Driver);
            HomePage = new HomePage(Driver);
            AddProjectPage = new AddProjectPage(Driver);
            ProjectsMenuPage = new ProjectsMenuPage(Driver);
            OverviewPage = new OverviewPage(Driver);
            TestCasesPage = new TestCasesPage(Driver);
            AddTestCasePage = new AddTestCasePage(Driver);
        }

        [TearDown]
        public void Close()
        {
            Driver?.Quit();
        }
    }
}
