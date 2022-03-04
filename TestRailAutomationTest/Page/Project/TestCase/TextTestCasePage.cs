using OpenQA.Selenium;
using TestRailAutomationTest.Model.TestCase;
using TestRailAutomationTest.Page.Constants;

namespace TestRailAutomationTest.Page.Project.TestCase
{
    public class TextTestCasePage : BaseTestCaseOverviewPage
    {
        public TextTestCasePage(IWebDriver? driver) : base(driver)
        {
        }

        public override TextTestCase GetTestCase()
        {
            var testCase = new TextTestCase();
            FillCommonFields(testCase);
            testCase.Preconditions = GetDescriptionProperty(TestCaseProperties.PreconditionsName);
            testCase.Steps = GetDescriptionProperty(TestCaseProperties.StepsName);
            testCase.ExpectedResult = GetDescriptionProperty(TestCaseProperties.ExpectedResultName);
            return testCase;
        }
    }
}
