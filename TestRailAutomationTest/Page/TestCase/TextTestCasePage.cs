using OpenQA.Selenium;
using TestRailAutomationTest.Model.TestCase;
using TestRailAutomationTest.Page.Constants;

namespace TestRailAutomationTest.Page.TestCase
{
    public class TextTestCasePage : BaseTestCaseOverviewPage
    {
        private readonly TextTestCase _testCase;
        
        public TextTestCasePage(IWebDriver? driver, TextTestCase testCase) : base(driver)
        {
            _testCase = testCase;
        }

        public override TextTestCase GetTestCase()
        {
            FillCommonFields(_testCase);
            _testCase.Preconditions = GetOptionalPropertyValue(TestCaseProperties.PreconditionsName);
            _testCase.Steps = GetOptionalPropertyValue(TestCaseProperties.StepsName);
            _testCase.ExpectedResult = GetOptionalPropertyValue(TestCaseProperties.ExpectedResultName);
            return _testCase;
        }
    }
}
