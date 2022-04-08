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
            _testCase.Preconditions = GetDescriptionProperty(TestCaseProperties.PreconditionsName);
            _testCase.Steps = GetDescriptionProperty(TestCaseProperties.StepsName);
            _testCase.ExpectedResult = GetDescriptionProperty(TestCaseProperties.ExpectedResultName);
            return _testCase;
        }
    }
}
