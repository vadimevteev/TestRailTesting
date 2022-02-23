using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using TestRailAutomationTest.Page.Constants;
using TestRailAutomationTest.Utils;

namespace TestRailAutomationTest.Page.Project.TestCase;

public class TestCaseOverviewPage : BasePage
{
    public const string PageName = "TestCase Overview Page";
    private const string PropertyExample = "EXAMPLE";
    private static readonly By TitleLocation = By.XPath("//div[@id=\"content-header\"]//div[contains(@class,\"title\")]");
    public static readonly By SectionLocation = By.XPath("//a[@id=\"navigation-cases-section\"]");
    private const string CommonPropertyLocation = "//table[@class=\"io\"]//td[@id=\"cell_" + PropertyExample +"\"]";
    
    public TestCaseOverviewPage(IWebDriver? driver) : base(driver)
    {
    }

    public Model.TestCase.BaseTestCase GetTestCase()
    {
        var testCase = new Model.TestCase.BaseTestCase();
        testCase.Title = GetTitle();
        testCase.Section = GetSection();
        testCase.Type = GetPropertyValue(TestCaseProperties.TestCaseTypePropertyName);
        testCase.Priority = GetPropertyValue(TestCaseProperties.PriorityPropertyName);
        testCase.Estimate = ConvertTimeToMinutes(GetPropertyValue(TestCaseProperties.EstimatePropertyName));
        testCase.References = GetPropertyValue(TestCaseProperties.ReferencesPropertyName);
        testCase.AutomationType = GetPropertyValue(TestCaseProperties.AutomationTypePropertyName);
        
        return testCase;
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
        return GetTextFromElement(GetPropertyPath(property)).Split('\n').Last();
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
    
    private static By GetPropertyPath(string propertyName)
    {
        return By.XPath(CommonPropertyLocation.Replace(PropertyExample, propertyName));
    }
}
