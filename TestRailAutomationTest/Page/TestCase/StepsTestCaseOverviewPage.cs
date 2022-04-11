using OpenQA.Selenium;
using TestRailAutomationTest.Model.TestCase;
using TestRailAutomationTest.Page.Constants;

namespace TestRailAutomationTest.Page.TestCase
{
    public class StepsTestCaseOverviewPage : BaseTestCaseOverviewPage
    {
        private readonly StepsTestCase _testCase;
        private static readonly By StepDescriptionLocation = By.XPath("//div[contains(@class,\"hidden-vertical\")]//p");
        private static readonly By StepExpectedResultLocation =
            By.XPath("//td[contains(@class, \"hidden-vertical\")]//p");
        
        public StepsTestCaseOverviewPage(IWebDriver? driver, StepsTestCase testCase) : base(driver)
        {
            _testCase = testCase;
        }

        public override StepsTestCase GetTestCase()
        {
            FillCommonFields(_testCase);
            _testCase.Preconditions = GetOptionalPropertyValue(TestCaseProperties.PreconditionsName);
            _testCase.StepDescription = GetOptionalPropertyValueByXpath(StepDescriptionLocation);
            _testCase.StepExpectedResult = GetOptionalPropertyValueByXpath(StepExpectedResultLocation);
            return _testCase;   
        }
    }
}
