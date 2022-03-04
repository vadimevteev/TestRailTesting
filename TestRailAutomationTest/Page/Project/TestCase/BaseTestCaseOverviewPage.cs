using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using TestRailAutomationTest.Model.TestCase;
using TestRailAutomationTest.Page.Constants;

namespace TestRailAutomationTest.Page.Project.TestCase
{

    public abstract class BaseTestCaseOverviewPage : BasePage
    {
        public const string PageName = "TestCase Overview Page";
        private static readonly By TitleLocation =
            By.XPath("//div[@id=\"content-header\"]//div[contains(@class,\"title\")]");
        public static readonly By SectionLocation = By.XPath("//a[@id=\"navigation-cases-section\"]");
        private const string CommonPropertyLocation = $"//table[@class=\"io\"]//td[@id=\"cell_{Example}\"]";
        private const string CommonDescriptionLocation = $"//span[text()=\"{Example}\"]/../following-sibling::div//p";

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
            testCase.Estimate = ConvertTimeToMinutes(GetRequiredPropertyValue(TestCaseProperties.Estimate));
            testCase.References = GetRequiredPropertyValue(TestCaseProperties.References);
            testCase.AutomationType = " " + GetRequiredPropertyValue(TestCaseProperties.AutomationType);
        }

        private string GetRequiredPropertyValue(string property)
        {
            return GetTextFromElement(GetElementLocation(CommonPropertyLocation, property)).Split('\n').Last();
        }

        protected string? GetDescriptionProperty(string value)
        {
            return GetOptionalValue(GetElementLocation(CommonDescriptionLocation, value));
        }

        protected string? GetOptionalValue(By location)
        {
            return IsElementExistOnPage(location) ? GetTextFromElement(location) : null;
        }

        private static int ConvertTimeToMinutes(string time)
        {
            const string pattern = @"[0-9]+";
            var timeMeasurements = new List<int>();
            foreach (Match match in Regex.Matches(time, pattern))
            {
                timeMeasurements.Add(int.Parse(match.Value));
            }

            var result = 0;
            if (time.Contains("hour"))
            {
                result = timeMeasurements.FirstOrDefault() * 60;
            }

            if (time.Contains("minute"))
            {
                result += timeMeasurements.Last();
            }

            return result;
        }
    }
}
