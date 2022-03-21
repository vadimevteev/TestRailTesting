using FluentAssertions;
using NUnit.Framework;
using TestRailAutomationTest.Page.Project.TestCase;
using TestRailAutomationTest.Service;
using TestRailAutomationTest.Steps;

namespace TestRailAutomationTest.Test
{
    public class CreateTestCase : BaseTest
    {
        [Test, Description(
             "Create test case with required fields should be successful, " +
             "test case with required fields should be created")]
        public void CreateTestCase_WithRequiredFields_ShouldBeSuccessful()
        {
            LoginSteps.Login(LoginPage, Users);
            var project = ProjectCreator.CreateRandomRequiredFields();
            ProjectSteps.CreateProject(HomePage, CreateProjectPage, ProjectsMenuPage, project);
            ProjectSteps.OpenProject(HomePage, project);
            var expectedTest = TestCaseCreator.CreateRandomRequiredFields();
            TestCaseSteps.CreateTestCase(ProjectOverviewPage,TestCasesMenuPage,CreateTestCasePage,expectedTest);
            DefaultTestCaseOverViewPage.WaitForOpen(BaseTestCaseOverviewPage.PageName,
                BaseTestCaseOverviewPage.SectionLocation);
            var actualTest = DefaultTestCaseOverViewPage.GetTestCase();
            expectedTest.Should()
                .BeEquivalentTo(actualTest, options => options.Excluding(o => o.Template));
        }
        
        [Test, Description(
             "Create test case with all fields with exploratory template should be successful, " +
             "test case with all current fields should be created")]
        public void CreateTestCase_WithExploratoryTemplateAndAllFields_ShouldBeSuccessful()
        {
            LoginSteps.Login(LoginPage, Users);
            var project = ProjectCreator.CreateRandomRequiredFields();
            ProjectSteps.CreateProject(HomePage, CreateProjectPage, ProjectsMenuPage, project);
            ProjectSteps.OpenProject(HomePage, project);
            var expectedTest = TestCaseCreator.CreateRandomExploratoryTemplate();
            TestCaseSteps.CreateTestCase(ProjectOverviewPage,TestCasesMenuPage,CreateTestCasePage,expectedTest);
            ExploratoryTestCaseOverviewPage.WaitForOpen(BaseTestCaseOverviewPage.PageName,
                BaseTestCaseOverviewPage.SectionLocation);
            var actualTest = ExploratoryTestCaseOverviewPage.GetTestCase();
            expectedTest.Should()
                .BeEquivalentTo(actualTest, options => options.Excluding(o => o.Template));
        }
        
        [Test, Description(
             "Create test case with all fields with steps template should be successful, " +
             "test case with all current fields should be created")]
        public void CreateTestCase_WithStepsTemplateAndAllFields_ShouldBeSuccessful()
        {
            LoginSteps.Login(LoginPage, Users);
            var project = ProjectCreator.CreateRandomRequiredFields();
            ProjectSteps.CreateProject(HomePage, CreateProjectPage, ProjectsMenuPage, project);
            ProjectSteps.OpenProject(HomePage, project);
            var expectedTest = TestCaseCreator.CreateRandomStepsTemplate();
            TestCaseSteps.CreateTestCase(ProjectOverviewPage,TestCasesMenuPage,CreateTestCasePage,expectedTest);
            StepsTestCaseOverviewPage.WaitForOpen(BaseTestCaseOverviewPage.PageName,
                BaseTestCaseOverviewPage.SectionLocation);
            var actualTest = StepsTestCaseOverviewPage.GetTestCase();
            expectedTest.Should()
                .BeEquivalentTo(actualTest, options => options.Excluding(o => o.Template));
        }
        
        [Test, Description(
             "Create test case with all fields with text template should be successful, " +
             "test case with all current fields should be created")]
        public void CreateTestCase_WithTextTemplateAndAllFields_ShouldBeSuccessful()
        {
            LoginSteps.Login(LoginPage, Users);
            var project = ProjectCreator.CreateRandomRequiredFields();
            ProjectSteps.CreateProject(HomePage, CreateProjectPage, ProjectsMenuPage, project);
            ProjectSteps.OpenProject(HomePage, project);
            var expectedTest = TestCaseCreator.CreateRandomTextType();
            TestCaseSteps.CreateTestCase(ProjectOverviewPage,TestCasesMenuPage,CreateTestCasePage,expectedTest);
            TextTestCasePage.WaitForOpen(BaseTestCaseOverviewPage.PageName,
                BaseTestCaseOverviewPage.SectionLocation);
            var actualTest = TextTestCasePage.GetTestCase();
            expectedTest.Should()
                .BeEquivalentTo(actualTest, options => options.Excluding(o => o.Template));
        }
    }
}
