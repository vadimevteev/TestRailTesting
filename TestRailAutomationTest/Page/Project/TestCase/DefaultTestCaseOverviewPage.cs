using OpenQA.Selenium;
using TestRailAutomationTest.Model.TestCase;

namespace TestRailAutomationTest.Page.Project.TestCase
{

    public class DefaultTestCaseOverviewPage : BaseTestCaseOverviewPage
    {
        public DefaultTestCaseOverviewPage(IWebDriver? driver) : base(driver)
        {
        }

        public DefaultTestCase GetTestCase()
        {
            var testCase = new DefaultTestCase();
            FillCommonFields(testCase);
            return testCase;
        }
    }
}


