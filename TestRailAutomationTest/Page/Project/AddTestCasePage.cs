using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestRailAutomationTest.Model.TestCase;
using TestRailAutomationTest.Utils;

namespace TestRailAutomationTest.Page.Project;

public class AddTestCasePage : BasePage
{
    public const string PageName = "Add test case page";
    public static readonly By HeaderTitleLocation =
        By.XPath("//*[@id=\"content-header\"]//div[contains(text(),'Add Test Case')]");
    private const string SectionPropertyName = "section_id";
    private const string TemplatePropertyName = "template_id";
    private const string TestCaseTypePropertyName = "type_id";
    private const string PriorityPropertyName = "priority_id";
    private const string AutomationTypePropertyName = "custom_automation_type";
    private static readonly By TitlePropertyLocation = By.XPath("//input[@id=\"title\"]");
    private static readonly By EstimatePropertyLocation = By.XPath("//input[@id=\"estimate\"]");
    private static readonly By ReferencesPropertyLocation = By.XPath("//input[@id=\"refs\"]");
    private static readonly By PreconditionsInputLocation = By.XPath("//div[@id=\"custom_preconds_display\"]");
    private static readonly By StepsInputLocation = By.XPath("//div[@id=\"custom_steps_display\"]");
    private static readonly By ExpectedResultInputLocation = By.XPath("//div[@id=\"custom_expected_display\"]");
    private static readonly By SectionAllTypesLocation =
        By.XPath("//div[@id=\"section_id_chzn\"]//ul[@class=\"chzn-results\"]/li");
    private const string CommonPropertyListLocation = "//div[@id=\"EXAMPLE_PROPERTY_chzn\"]/a";
    private const string CommonPropertyValueLocation = "//div[@id=\"EXAMPLE_PROPERTY_chzn\"]//li[contains(text(),'EXAMPLE_VALUE')]";
    
    private static readonly By AcceptButtonLocation = By.XPath("//button[@id=\"accept\"]");
    
    public AddTestCasePage(IWebDriver? driver) : base(driver)
    {
    }
    
    public AddTestCasePage FillTestCaseForm(TestCase testCase)
    {
        ClickButton(TitlePropertyLocation);
        FillInput(TitlePropertyLocation, testCase.Title);
        
        ClickButton(FindPropertyList(SectionPropertyName));
        ClickButton(FindPropertyValue(SectionPropertyName,testCase.Section));
        
        ClickButton(FindPropertyList(TemplatePropertyName));
        ClickButton(FindPropertyValue(TemplatePropertyName,testCase.Template));
        
        ClickButton(FindPropertyList(TestCaseTypePropertyName));
        ClickButton(FindPropertyValue(TestCaseTypePropertyName,testCase.Type));
        
        ClickButton(FindPropertyList(PriorityPropertyName));
        ClickButton(FindPropertyValue(PriorityPropertyName,testCase.Priority));
        
        ClickButton(EstimatePropertyLocation);
        FillInput(EstimatePropertyLocation, testCase.Estimate);
        
        ClickButton(ReferencesPropertyLocation);
        FillInput(ReferencesPropertyLocation, testCase.References);
        
        ClickButton(FindPropertyList(AutomationTypePropertyName));
        ClickButton(FindPropertyValue(AutomationTypePropertyName, testCase.AutomationType));
        
        ClickButton(PreconditionsInputLocation);
        FillInput(PreconditionsInputLocation, testCase.Preconditions);
        
        ClickButton(StepsInputLocation);
        FillInput(StepsInputLocation, testCase.Steps);
        
        ClickButton(ExpectedResultInputLocation);
        FillInput(ExpectedResultInputLocation, testCase.ExpectedResult);
        return this;
    }

    private static By FindPropertyValue(string propertyName, string value)
    {
        return By.XPath(CommonPropertyValueLocation.Replace("EXAMPLE_PROPERTY", propertyName)
            .Replace("EXAMPLE_VALUE", value));
    }

    private static By FindPropertyList(string propertyName)
    {
        return By.XPath(CommonPropertyListLocation.Replace("EXAMPLE_PROPERTY", propertyName));
    }

    public void ClickAcceptButton()
    {
        ClickButton(AcceptButtonLocation);
    }

    public IEnumerable<string> GetSectionList()
    { 
      ClickButton(FindPropertyList(SectionPropertyName));
      return Waits.WaitAllElementsExistence(Driver,SectionAllTypesLocation).Select(p => p.Text);
    }
}
