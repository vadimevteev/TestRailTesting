using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using TestRailAutomationTest.Driver;
using TestRailAutomationTest.Model;
using TestRailAutomationTest.Model.TestCase;
using TestRailAutomationTest.Page;
using TestRailAutomationTest.Page.Project;
using TestRailAutomationTest.Page.TestCase;
using TestRailAutomationTest.Page.TestCase.CreateTestCasePage;
using TestRailAutomationTest.Service;
using TestRailAutomationTest.Steps;

namespace TestRailAutomationTest.Test
{
    public abstract class BaseTest
    {
        public static readonly string LoginPageUrl = DataReader.GetConfig().AppUrl;
        private IWebDriver? Driver;
        protected List<User?> Users;
        protected LoginPage LoginPage;
        protected HomePage HomePage;
        protected CreateProjectPage CreateProjectPage;
        protected ProjectsMenuPage ProjectsMenuPage;
        protected ProjectOverviewPage ProjectOverviewPage;
        protected TestCasesMenuPage TestCasesMenuPage;
        protected CreateTestCasePage CreateTestCasePage;
        protected DefaultTestCaseOverviewPage DefaultTestCaseOverViewPage;
        protected ExploratoryTestCaseOverviewPage ExploratoryTestCaseOverviewPage;
        protected TextTestCasePage TextTestCasePage;
        protected StepsTestCaseOverviewPage StepsTestCaseOverviewPage;
        protected LoginSteps LoginSteps;
        protected ProjectSteps ProjectSteps;

        [SetUp]
        public void Init()
        {
            Driver = DriverFactory.GetDriver();
            Users = DataReader.GetConfig().Users;
            LoginPage = new LoginPage(Driver);
            HomePage = new HomePage(Driver);
            CreateProjectPage = new CreateProjectPage(Driver);
            ProjectsMenuPage = new ProjectsMenuPage(Driver);
            ProjectOverviewPage = new ProjectOverviewPage(Driver);
            TestCasesMenuPage = new TestCasesMenuPage(Driver);
            CreateTestCasePage = new CreateTestCasePage(Driver);
            DefaultTestCaseOverViewPage = new DefaultTestCaseOverviewPage(Driver, new DefaultTestCase());
            ExploratoryTestCaseOverviewPage = new ExploratoryTestCaseOverviewPage(Driver, new ExploratoryTestCase());
            TextTestCasePage = new TextTestCasePage(Driver, new TextTestCase());
            StepsTestCaseOverviewPage = new StepsTestCaseOverviewPage(Driver, new StepsTestCase());
            LoginSteps = new LoginSteps(LoginPage);
            ProjectSteps = new ProjectSteps(HomePage, CreateProjectPage, ProjectsMenuPage, ProjectOverviewPage);
        }

        [TearDown]
        public void Close()
        {
            Driver?.Quit();
        }
    }
}
