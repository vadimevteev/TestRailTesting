using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using TestRailAutomationTest.Service;
using TestRailAutomationTest.Steps;

namespace TestRailAutomationTest.Test
{
    public class CreateTestCase : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            LoginSteps loginSteps = new(LoginPage, Users.FirstOrDefault()!);
            var project = ProjectCreator.CreateRandomRequiredFields();
            ProjectSteps projectSteps = new(HomePage, CreateProjectPage, ProjectsMenuPage, project);
            loginSteps.Login();
            projectSteps.CreateProject();
            projectSteps.OpenProject();
        }
        
        [Test, Description(
             "Create test case with required fields should be successful, " +
             "test case with required fields should be created")]
        public void CreateTestCase_WithRequiredFields_ShouldBeSuccessful()
        {
            var expectedTest = TestCaseCreator.CreateRandomRequiredFields();
            TestCaseSteps testCaseSteps =
                new(ProjectOverviewPage, TestCasesMenuPage, CreateTestCasePage, DefaultTestCaseOverViewPage, expectedTest);
            
            testCaseSteps.CreateTestCase();
            var actualTest = testCaseSteps.GetActualTestCase();
            
            expectedTest.Should()
                .BeEquivalentTo(actualTest, options => options.RespectingRuntimeTypes()
                    .Excluding(o => o.Template));
        }
        
        [Test, Description(
             "Create test case with all fields with exploratory template should be successful, " +
             "test case with all current fields should be created")]
        public void CreateTestCase_WithExploratoryTemplateAndAllFields_ShouldBeSuccessful()
        {
            var expectedTest = TestCaseCreator.CreateRandomExploratoryTemplate();
            TestCaseSteps testCaseSteps =
                new(ProjectOverviewPage, TestCasesMenuPage, CreateTestCasePage, ExploratoryTestCaseOverviewPage, expectedTest);
            
            testCaseSteps.CreateTestCase();
            var actualTest = testCaseSteps.GetActualTestCase();
            
            expectedTest.Should()
                .BeEquivalentTo(actualTest, options => options.RespectingRuntimeTypes()
                    .Excluding(o => o.Template));
        }
        
        [Test, Description(
             "Create test case with all fields with steps template should be successful, " +
             "test case with all current fields should be created")]
        public void CreateTestCase_WithStepsTemplateAndAllFields_ShouldBeSuccessful()
        {
            var expectedTest = TestCaseCreator.CreateRandomStepsTemplate();
            TestCaseSteps testCaseSteps =
                new(ProjectOverviewPage, TestCasesMenuPage, CreateTestCasePage, StepsTestCaseOverviewPage, expectedTest);
            
            testCaseSteps.CreateTestCase();
            var actualTest = testCaseSteps.GetActualTestCase();
            
            expectedTest.Should()
                .BeEquivalentTo(actualTest, options => options.RespectingRuntimeTypes()
                    .Excluding(o => o.Template));
        }
        
        [Test, Description(
             "Create test case with all fields with text template should be successful, " +
             "test case with all current fields should be created")]
        public void CreateTestCase_WithTextTemplateAndAllFields_ShouldBeSuccessful()
        {
            var expectedTest = TestCaseCreator.CreateRandomTextType();
            TestCaseSteps testCaseSteps =
                new(ProjectOverviewPage, TestCasesMenuPage, CreateTestCasePage, TextTestCasePage, expectedTest);
            
            testCaseSteps.CreateTestCase();
            var actualTest = testCaseSteps.GetActualTestCase();
            
            expectedTest.Should()
                .BeEquivalentTo(actualTest, options => options.RespectingRuntimeTypes()
                    .Excluding(o => o.Template));
        }
    }
}
