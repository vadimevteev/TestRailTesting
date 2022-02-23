using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestRailAutomationTest.Exception;
using TestRailAutomationTest.Model.TestCase;
using TestRailAutomationTest.Page.Constants;
using TestRailAutomationTest.Utils;

namespace TestRailAutomationTest.Page.Project;

public class CreateTestCasePage : BasePage
{
    public const string PageName = "Add test case page";
    public static readonly By HeaderTitleLocation =
        By.XPath("//*[@id=\"content-header\"]//div[contains(text(),'Add Test Case')]");

    //required fields
    private static readonly By TitlePropertyLocation = By.XPath("//input[@id=\"title\"]");
    private static readonly By EstimatePropertyLocation = By.XPath("//input[@id=\"estimate\"]");
    private static readonly By ReferencesPropertyLocation = By.XPath("//input[@id=\"refs\"]");
    //test case text
    private static readonly By PreconditionsInputLocation = By.XPath("//div[@id=\"custom_preconds_display\"]");
    private static readonly By StepsInputLocation = By.XPath("//div[@id=\"custom_steps_display\"]");
    private static readonly By ExpectedResultInputLocation = By.XPath("//div[@id=\"custom_expected_display\"]");
    //exploratory 
    private static readonly By MissionInputLocation = By.XPath("//div[@id=\"custom_mission_display\"]");
    private static readonly By GoalsInputLocation = By.XPath("//div[@id=\"custom_goals_display\"]");
    //test case steps
    private static readonly By AddTestCaseButton =
        By.XPath("//div[@id=\"custom_steps_separated_container\"]//a[@class=\"addStep\"]");
    private static readonly By StepDescriptionInputLocation =
        By.XPath("//td[@class=\"step-content\"]//div[@placeholder=\"Step Description\"]");
    private static readonly By StepExpectedResultInputLocation =
        By.XPath("//td[@class=\"step-content\"]//div[@placeholder=\"Expected Result\"]");
    
    private static readonly By SectionAllTypesLocation =
        By.XPath("//div[@id=\"section_id_chzn\"]//ul[@class=\"chzn-results\"]/li");

    private const string PropertyExample = "EXAMPLE_PROPERTY";
    private const string PropertyValueExample = "EXAMPLE_VALUE";
    private const string CommonPropertyListLocation = "//div[@id=\"" + PropertyExample + "_chzn\"]/a";
    private const string CommonPropertyValueLocation = "//div[@id=\"" + PropertyExample + "_chzn\"]//li[contains(text(),'" + PropertyValueExample +"')]";
    
    private static readonly By AcceptButtonLocation = By.XPath("//button[@id=\"accept\"]");
    
    public CreateTestCasePage(IWebDriver? driver) : base(driver)
    {
    }
    
    public CreateTestCasePage FillTestCaseForm(Model.TestCase.BaseTestCase baseTestCase)
    {
        FillInputAfterClick(TitlePropertyLocation, baseTestCase.Title);
        ChoosePropertyValue(TestCaseProperties.TemplatePropertyName, baseTestCase.Template);
        try
        {
            ChoosePropertyValue(TestCaseProperties.TestCaseTypePropertyName, baseTestCase.Type);
        }
        catch (StaleElementReferenceException)
        {
            ChoosePropertyValue(TestCaseProperties.TestCaseTypePropertyName, baseTestCase.Type);
        }
        ChoosePropertyValue(TestCaseProperties.SectionPropertyName,baseTestCase.Section);
        ChoosePropertyValue(TestCaseProperties.PriorityPropertyName,baseTestCase.Priority);
        FillInputAfterClick(EstimatePropertyLocation, baseTestCase.Estimate.ToString());
        FillInputAfterClick(ReferencesPropertyLocation, baseTestCase.References);
        ChoosePropertyValue(TestCaseProperties.AutomationTypePropertyName, baseTestCase.AutomationType);
        FillDescription(baseTestCase);
        return this;
    }

    private void FillDescription(Model.TestCase.BaseTestCase baseTestCase)
    {
        switch (baseTestCase.Template)
        {
            case "Exploratory Session":
                FillInputAfterClick(MissionInputLocation, baseTestCase.Mission);
                FillInputAfterClick(GoalsInputLocation, baseTestCase.Goals);
                break;
            case "Test Case (Steps)":
                FillInputAfterClick(PreconditionsInputLocation, baseTestCase.Preconditions);
                ClickButton(AddTestCaseButton);
                FillInputAfterClick(StepDescriptionInputLocation, baseTestCase.StepDescription);
                FillInputAfterClick(StepExpectedResultInputLocation, baseTestCase.StepExpectedResult);
                break;
            case "Test Case (Text)":
                FillInputAfterClick(PreconditionsInputLocation, baseTestCase.Preconditions);
                FillInputAfterClick(StepsInputLocation, baseTestCase.Steps);
                FillInputAfterClick(ExpectedResultInputLocation, baseTestCase.ExpectedResult);
                break;
            default:
                throw new IncorrectDataException($"{baseTestCase.Section} section type is incorrect");
        }
    }
    
    private void ChoosePropertyValue(string propertyName, string value)
    {
        ClickButton(FindPropertyList(propertyName));
        ClickButton(FindPropertyValue(propertyName,value));
    }

    private static By FindPropertyValue(string propertyName, string value)
    {
        return By.XPath(CommonPropertyValueLocation.Replace(PropertyExample, propertyName)
            .Replace(PropertyValueExample, value));
    }

    private static By FindPropertyList(string propertyName)
    {
        return By.XPath(CommonPropertyListLocation.Replace(PropertyExample, propertyName));
    }

    public void ClickAcceptButton()
    {
        ClickButton(AcceptButtonLocation);
    }

    public IEnumerable<string> GetSectionList()
    { 
      ClickButton(FindPropertyList(TestCaseProperties.SectionPropertyName));
      return Waits.WaitAllElementsExistence(Driver,SectionAllTypesLocation).Select(p => p.Text);
    }
}
