using OpenQA.Selenium;
using TestRailAutomationTest.Model.TestCase;
using TestRailAutomationTest.Page.Constants;

namespace TestRailAutomationTest.Page.Project.TestCase
{
    public class ExploratoryTestCaseOverviewPage : BaseTestCaseOverviewPage
    {
        public ExploratoryTestCaseOverviewPage(IWebDriver? driver) : base(driver)
        {
        }

        public override ExploratoryTestCase GetTestCase()
        {
            var testCase = new ExploratoryTestCase();
            FillCommonFields(testCase);
            testCase.Goals = GetDescriptionProperty(TestCaseProperties.GoalsName);
            testCase.Mission = GetDescriptionProperty(TestCaseProperties.MissionName);
            return testCase;
        }
    }
}
