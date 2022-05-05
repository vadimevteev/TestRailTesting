using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using TestRailAutomationTest.Client;
using TestRailAutomationTest.Service;
using TestRailAutomationTest.Steps;

namespace TestRailAutomationTest.Test
{
    public class CreateTestCase : BaseTest
    {
        [SetUp]
        public async void SetUp()
        {
            var client = new HttpClient(DataReader.GetConfig().AppUrl);
            var project = ProjectCreator.CreateRandomRequiredFields();
            client.Login(Users.FirstOrDefault()!);
            await ProjectService.CreateProject(client, project);
            LoginSteps.Login(Users.FirstOrDefault()!);
            ProjectSteps.OpenProject(project);
        }

        [Test, Description(
             "Create test case with required fields should be successful, " +
             "test case with required fields should be created")]
        public void CreateTestCase_WithRequiredFields_ShouldBeSuccessful()
        {
            var expectedTest = TestCaseCreator.CreateRandomRequiredFields();
            TestCaseSteps testCaseSteps =
                new(ProjectOverviewPage, TestCasesMenuPage, CreateTestCasePage, DefaultTestCaseOverViewPage);
            
            testCaseSteps.CreateTestCase(expectedTest);
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
                new(ProjectOverviewPage, TestCasesMenuPage, CreateTestCasePage, ExploratoryTestCaseOverviewPage);
            
            testCaseSteps.CreateTestCase(expectedTest);
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
                new(ProjectOverviewPage, TestCasesMenuPage, CreateTestCasePage, StepsTestCaseOverviewPage);
            
            testCaseSteps.CreateTestCase(expectedTest);
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
                new(ProjectOverviewPage, TestCasesMenuPage, CreateTestCasePage, TextTestCasePage);
            
            testCaseSteps.CreateTestCase(expectedTest);
            var actualTest = testCaseSteps.GetActualTestCase();
            
            expectedTest.Should()
                .BeEquivalentTo(actualTest, options => options.RespectingRuntimeTypes()
                    .Excluding(o => o.Template));
        }
    }
}
