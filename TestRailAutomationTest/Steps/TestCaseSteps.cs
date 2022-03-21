using TestRailAutomationTest.Model.TestCase;
using TestRailAutomationTest.Page.Project;

namespace TestRailAutomationTest.Steps
{
    public static class TestCaseSteps
    {
        public static void CreateTestCase(ProjectOverviewPage projectOverviewPage, TestCasesMenuPage testCasesMenuPage, CreateTestCasePage createTestCasePage, BaseTestCase testCase)
        {
            projectOverviewPage.WaitForOpen(ProjectOverviewPage.PageName, ProjectOverviewPage.ChartLineLocation);
            projectOverviewPage.OpenTestCasesPage();

            testCasesMenuPage.WaitForOpen(TestCasesMenuPage.PageName, TestCasesMenuPage.HeaderTitleLocation);
            testCasesMenuPage.AddTestCase();

            createTestCasePage.WaitForOpen(CreateTestCasePage.PageName, CreateTestCasePage.HeaderTitleLocation);
            createTestCasePage.FillTestCaseForm(testCase);
            createTestCasePage.ClickAcceptButton();
        }
    }
}
