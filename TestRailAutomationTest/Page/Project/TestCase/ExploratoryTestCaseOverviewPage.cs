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

        public ExploratoryTestCase GetTestCase()
        {
            var testCase = new ExploratoryTestCase();
            FillCommonFields(testCase);
            testCase.Goals = GetDescriptionPropertyValue(TestCaseProperties.Goals);
            testCase.Mission = GetDescriptionPropertyValue(TestCaseProperties.Mission);
            return testCase;
        }
    }
}
