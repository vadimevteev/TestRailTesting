using System.Linq;
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
        [Test, Description(
             "Create test case with required fields should be successful, " +
             "test case with required fields should be created")]
        public void CreateTestCase_WithRequiredFields_ShouldBeSuccessful()
        {
            CreateTestCaseTest(TestCaseCreator.CreateRandomRequiredFields(), DefaultTestCaseOverViewPage);
        }
        
        [Test, Description(
             "Create test case with all fields with exploratory template should be successful, " +
             "test case with all current fields should be created")]
        public void CreateTestCase_WithExploratoryTemplateAndAllFields_ShouldBeSuccessful()
        {
            CreateTestCaseTest(TestCaseCreator.CreateRandomExploratoryTemplate(), ExploratoryTestCaseOverviewPage);
        }
        
        [Test, Description(
             "Create test case with all fields with steps template should be successful, " +
             "test case with all current fields should be created")]
        public void CreateTestCase_WithStepsTemplateAndAllFields_ShouldBeSuccessful()
        {
            CreateTestCaseTest(TestCaseCreator.CreateRandomStepsTemplate(), StepsTestCaseOverviewPage);
            
        }
        
        [Test, Description(
             "Create test case with all fields with text template should be successful, " +
             "test case with all current fields should be created")]
        public void CreateTestCase_WithTextTemplateAndAllFields_ShouldBeSuccessful()
        {
            CreateTestCaseTest(TestCaseCreator.CreateRandomTextType(), TextTestCasePage);
        }

        private void CreateTestCaseTest(BaseTestCase expectedTest, BaseTestCaseOverviewPage currentPage)
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
            CreateTestCasePage.FillTestCaseForm(expectedTest);
            CreateTestCasePage.ClickAcceptButton();

            currentPage.WaitForOpen(BaseTestCaseOverviewPage.PageName,
                BaseTestCaseOverviewPage.SectionLocation);
            var actualTest = currentPage.GetTestCase();
            expectedTest.Should()
                .BeEquivalentTo(actualTest, options => options.RespectingRuntimeTypes()
                    .Excluding(o => o.Template));
        }
    }
}
