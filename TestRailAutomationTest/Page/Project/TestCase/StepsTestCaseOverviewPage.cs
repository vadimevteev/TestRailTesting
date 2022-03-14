using OpenQA.Selenium;
using TestRailAutomationTest.Model.TestCase;
using TestRailAutomationTest.Page.Constants;

namespace TestRailAutomationTest.Page.Project.TestCase
{
    public class StepsTestCaseOverviewPage : BaseTestCaseOverviewPage
    {
        private static readonly By StepDescriptionLocation = By.XPath("//div[contains(@class,\"hidden-vertical\")]//p");
        private static readonly By StepExpectedResultLocation =
            By.XPath("//td[contains(@class, \"hidden-vertical\")]//p");
        
        public StepsTestCaseOverviewPage(IWebDriver? driver) : base(driver)
        {
        }

        public override StepsTestCase GetTestCase()
        {
            var testCase = new StepsTestCase();
            FillCommonFields(testCase);
            testCase.Preconditions = GetDescriptionProperty(TestCaseProperties.PreconditionsName);
            testCase.StepDescription = GetOptionalValue(StepDescriptionLocation);
            testCase.StepExpectedResult = GetOptionalValue(StepExpectedResultLocation);
            return testCase;
        }
    }
}
