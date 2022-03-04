using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using FluentAssertions;
using NUnit.Framework;
using TestRailAutomationTest.Model.TestCase;
using TestRailAutomationTest.Page;
using TestRailAutomationTest.Page.Project;
using TestRailAutomationTest.Page.Project.TestCase;
using TestRailAutomationTest.Service;

namespace TestRailAutomationTest.Test
{
    
    public class CreateTestCase : BaseTest
    {
        [Test]
        public void CreateTestCase_WithRequiredAndAllFields_ShouldBeSuccessful()
        {
            test(TestCaseCreator.CreateRandomRequiredFields(), DefaultTestCaseOverViewPage);
        }
        
        [Test]
        public void CreateTestCase_WithRequiredAndAllFields_ShouldBeSuccessful2()
        {
            test(TestCaseCreator.CreateRandomExploratoryTemplate(), ExploratoryTestCaseOverviewPage);
        }
        [Test]
        public void CreateTestCase_WithRequiredAndAllFields_ShouldBeSuccessful3()
        {
            test(TestCaseCreator.CreateRandomStepsTemplate(), StepsTestCaseOverviewPage);
            
        }
        [Test]
        public void CreateTestCase_WithRequiredAndAllFields_ShouldBeSuccessful4()
        {
            test(TestCaseCreator.CreateRandomTextType(), TextTestCasePage);
        }

        public void test(BaseTestCase tc, BaseTestCaseOverviewPage bp)
        {
            LoginPage.OpenStartPage();
            LoginPage
                .FillLoginForm(Users.FirstOrDefault()!)
                .PressFindButton();

            HomePage.WaitForOpen(HomePage.PageName, HomePage.HeaderTitleLocation);
            HomePage
                .ClickAddProjectButton();

            CreateProjectPage.WaitForOpen(CreateProjectPage.PageName, CreateProjectPage.HeaderTitleLocation);

            var project = ProjectCreator.CreateRandomRequiredFields();
            CreateProjectPage
                .FillAddProjectForm(project)
                .PressAcceptButton();
            ProjectsMenuPage.WaitForOpen(ProjectsMenuPage.PageName, ProjectsMenuPage.MenuProjectItemSelected);
            ProjectsMenuPage.OpenHomePage();

            HomePage.WaitForOpen(HomePage.PageName, HomePage.HeaderTitleLocation);
            HomePage.OpenProject(project.Name);

            ProjectOverviewPage.WaitForOpen(ProjectOverviewPage.PageName, ProjectOverviewPage.ChartLineLocation);
            ProjectOverviewPage.OpenTestCasesPage();

            TestCasesMenuPage.WaitForOpen(TestCasesMenuPage.PageName, TestCasesMenuPage.HeaderTitleLocation);
            TestCasesMenuPage.AddTestCase();

            CreateTestCasePage.WaitForOpen(CreateTestCasePage.PageName, CreateTestCasePage.HeaderTitleLocation);
            CreateTestCasePage.FillTestCaseForm(tc);
            CreateTestCasePage.ClickAcceptButton();

            bp.WaitForOpen(BaseTestCaseOverviewPage.PageName,
                BaseTestCaseOverviewPage.SectionLocation);
            var actualTest = bp.GetTestCase();
            actualTest.Should()
                .BeEquivalentTo(tc, options => options.Excluding(o => o.Template));
        }
    }
}
