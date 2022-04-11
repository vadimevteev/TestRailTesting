using System.Linq;
using OpenQA.Selenium;
using TestRailAutomationTest.Model.TestCase;
using TestRailAutomationTest.Page.Constants;
using TestRailAutomationTest.Utils;

namespace TestRailAutomationTest.Page.TestCase
{

    public abstract class BaseTestCaseOverviewPage : BasePage
    {
        public const string PageName = "TestCase Overview Page";
        private static readonly By TitleLocation =
            By.XPath("//div[@id=\"content-header\"]//div[contains(@class,\"title\")]");
        public static readonly By SectionLocation = By.Id("navigation-cases-section");
        private static string RequiredPropertyId(string label) => $"cell_{label}";
        private static string OptionalPropertyXpath(string label) => $"//span[text()=\"{label}\"]/../following-sibling::div//p";

        public abstract BaseTestCase GetTestCase();

        protected BaseTestCaseOverviewPage(IWebDriver? driver) : base(driver)
        {
        }

        protected void FillCommonFields(BaseTestCase testCase)
        {
            testCase.Title = GetTextFromElement(TitleLocation);
            testCase.Section = GetTextFromElement(SectionLocation);
            testCase.Type = GetRequiredPropertyValue(TestCaseProperties.Type);
            testCase.Priority = GetRequiredPropertyValue(TestCaseProperties.Priority);
            FillOptionalFields(testCase);
        }

        
        private void FillOptionalFields(BaseTestCase testCase)
        {
            if (testCase is DefaultTestCase) return;
            testCase.Estimate =
                TestCaseHelper.ConvertTimeToMinutes(GetRequiredPropertyValue(TestCaseProperties.Estimate));
            testCase.References = GetRequiredPropertyValue(TestCaseProperties.References);
            //DEV_NOTE: Space is needed because on site this element has it
            testCase.AutomationType = " " + GetRequiredPropertyValue(TestCaseProperties.AutomationType);
        }

        private string GetRequiredPropertyValue(string property)
            => GetTextFromElement(By.Id(RequiredPropertyId(property))).Split('\n').Last();

        protected string? GetOptionalPropertyValue(string propertyName)
            => GetOptionalPropertyValueByXpath(By.XPath(OptionalPropertyXpath(propertyName)));

        protected string? GetOptionalPropertyValueByXpath(By location)
            => IsElementExistOnPage(location) ? GetTextFromElement(location) : null;
    }
}
