using TestRailAutomationTest.Model.TestCase;
using TestRailAutomationTest.Page.Project;
using TestRailAutomationTest.Page.Project.TestCase;
using TestRailAutomationTest.Page.Project.TestCase.CreateTestCasePage;

namespace TestRailAutomationTest.Steps
{
    public class TestCaseSteps
    {
        private readonly ProjectOverviewPage _projectOverviewPage;
        private readonly TestCasesMenuPage _testCasesMenuPage;
        private readonly CreateTestCasePage _createTestCasePage;
        private readonly BaseTestCaseOverviewPage _overviewPage;

        public TestCaseSteps(ProjectOverviewPage projectOverviewPage, TestCasesMenuPage testCasesMenuPage, CreateTestCasePage createTestCasePage, 
            BaseTestCaseOverviewPage overviewPage)
        {
            _projectOverviewPage = projectOverviewPage;
            _testCasesMenuPage = testCasesMenuPage;
            _createTestCasePage = createTestCasePage;
            _overviewPage = overviewPage;
        }

        public void CreateTestCase(BaseTestCase testCase)
        {
            _projectOverviewPage.WaitForOpen(ProjectOverviewPage.PageName, ProjectOverviewPage.ChartLineLocation);
            _projectOverviewPage.OpenTestCasesPage();
            _testCasesMenuPage.WaitForOpen(TestCasesMenuPage.PageName, TestCasesMenuPage.HeaderTitleLocation);
            _testCasesMenuPage.AddTestCase();
            _createTestCasePage.WaitForOpen(CreateTestCasePage.PageName, CreateTestCasePage.HeaderTitleLocation);
            _createTestCasePage.FillTestCaseForm(testCase);
            _createTestCasePage.ClickAcceptButton();
        }

        public BaseTestCase GetActualTestCase()
        {
            _overviewPage.WaitForOpen(BaseTestCaseOverviewPage.PageName, BaseTestCaseOverviewPage.SectionLocation);
            return _overviewPage.GetTestCase();
        }
    }
}
