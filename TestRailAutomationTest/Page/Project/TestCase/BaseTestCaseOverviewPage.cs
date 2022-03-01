using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using TestRailAutomationTest.Model.TestCase;
using TestRailAutomationTest.Page.Constants;

namespace TestRailAutomationTest.Page.Project.TestCase;

public abstract class BaseTestCaseOverviewPage : BasePage
{
    public const string PageName = "TestCase Overview Page";
    private static readonly By TitleLocation = By.XPath("//div[@id=\"content-header\"]//div[contains(@class,\"title\")]");
    public static readonly By SectionLocation = By.XPath("//a[@id=\"navigation-cases-section\"]");
    private const string CommonPropertyLocation = $"//table[@class=\"io\"]//td[@id=\"cell_{Example}\"]";

    protected BaseTestCaseOverviewPage(IWebDriver? driver) : base(driver)
    {
    }

    protected void FillRequiredFields(BaseTestCase testCase)
    {
        testCase.Title = GetTitle();
        testCase.Section = GetSection();
        testCase.Type = GetPropertyValue(TestCaseProperties.Type);
        testCase.Priority = GetPropertyValue(TestCaseProperties.Priority);
        testCase.Estimate = ConvertTimeToMinutes(GetPropertyValue(TestCaseProperties.Estimate));
        testCase.References = GetPropertyValue(TestCaseProperties.References);
        testCase.AutomationType = GetPropertyValue(TestCaseProperties.AutomationType);
    }

    private string GetTitle()
    {
        return GetTextFromElement(TitleLocation);
    }

    private string GetSection()
    {
        return GetTextFromElement(SectionLocation);
    }

    private string GetPropertyValue(string property)
    {
        return GetTextFromElement(GetElementLocation(CommonPropertyLocation, property)).Split('\n').Last();
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
