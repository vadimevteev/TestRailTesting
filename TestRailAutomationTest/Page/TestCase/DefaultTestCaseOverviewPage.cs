using OpenQA.Selenium;
using TestRailAutomationTest.Model.TestCase;

namespace TestRailAutomationTest.Page.TestCase
{
    public class DefaultTestCaseOverviewPage : BaseTestCaseOverviewPage
    {
        private readonly DefaultTestCase _testCase;
        
        public DefaultTestCaseOverviewPage(IWebDriver? driver, DefaultTestCase testCase) : base(driver)
        {
            _testCase = testCase;
        }

        public override DefaultTestCase GetTestCase()
        {
            FillCommonFields(_testCase);
            return _testCase;
        }
    }
}
