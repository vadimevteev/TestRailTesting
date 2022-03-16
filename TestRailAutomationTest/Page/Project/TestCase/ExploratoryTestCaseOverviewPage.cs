using OpenQA.Selenium;
using TestRailAutomationTest.Model.TestCase;
using TestRailAutomationTest.Page.Constants;

namespace TestRailAutomationTest.Page.Project.TestCase
{
    public class ExploratoryTestCaseOverviewPage : BaseTestCaseOverviewPage
    {
        private readonly ExploratoryTestCase _testCase;
        
        public ExploratoryTestCaseOverviewPage(IWebDriver? driver, ExploratoryTestCase testCase) : base(driver)
        {
            _testCase = testCase;
        }

        public override ExploratoryTestCase GetTestCase()
        {
            FillCommonFields(_testCase);
            _testCase.Goals = GetDescriptionProperty(TestCaseProperties.GoalsName);
            _testCase.Mission = GetDescriptionProperty(TestCaseProperties.MissionName);
            return _testCase;
        }
    }
}
