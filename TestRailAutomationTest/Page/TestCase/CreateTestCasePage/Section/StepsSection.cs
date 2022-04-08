using OpenQA.Selenium;
using TestRailAutomationTest.Model.TestCase;
using TestRailAutomationTest.Page.Constants;
using TestRailAutomationTest.WebElement.Service;
using TestRailAutomationTest.WebElement.Wrapper;

namespace TestRailAutomationTest.Page.TestCase.CreateTestCasePage.Section;

public class StepsSection
{
    private readonly IWebDriver? _driver;
    private const string AddTestCaseButtonPath = "//div[@id=\"custom_steps_separated_container\"]//a[@class=\"addStep\"]";

    public StepsSection(IWebDriver? driver)
    {
        _driver = driver;
    }

    private static string BuildStepTextAreaXpath(string label) => $"//td[@class=\"step-content\"]//div[@placeholder=\"{label}\"]";
    private Textarea PreconditionsArea(string label) => new(_driver, WrapperHelper.BuildTextAreaXpath(label), label);
    private ButtonLink AddStepButton => new(_driver, AddTestCaseButtonPath, "Add Step");
    private Textarea DescriptionArea => new(_driver, BuildStepTextAreaXpath(TestCaseProperties.StepDescriptionName), TestCaseProperties.StepDescriptionName);
    private Textarea ExpectedResultArea => new(_driver, BuildStepTextAreaXpath(TestCaseProperties.StepExpectedResultName), TestCaseProperties.StepExpectedResultName);
    
    
    public void FillSteps(BaseTestCase testCase)
    {
        PreconditionsArea(TestCaseProperties.Preconditions).SetValueAfterClick(((StepsTestCase)testCase).Preconditions);
        AddStepButton.Click();
        DescriptionArea.SetValueAfterClick(((StepsTestCase)testCase).StepDescription);
        ExpectedResultArea.SetValueAfterClick(((StepsTestCase)testCase).StepExpectedResult);
    }
}
