using OpenQA.Selenium;
using TestRailAutomationTest.Model.TestCase;
using TestRailAutomationTest.Page.Constants;
using TestRailAutomationTest.WebElement.Service;
using TestRailAutomationTest.WebElement.Wrapper;

namespace TestRailAutomationTest.Page.TestCase.CreateTestCasePage.Section;

public class TextSection
{
    private readonly IWebDriver? _driver;

    public TextSection(IWebDriver? driver)
    {
        _driver = driver;
    }

    private Textarea PreconditionsArea => new(_driver, WrapperHelper.BuildTextAreaXpath(TestCaseProperties.Preconditions),
        TestCaseProperties.Preconditions);
    private Textarea StepsArea => new(_driver, WrapperHelper.BuildTextAreaXpath(TestCaseProperties.Steps),
        TestCaseProperties.Steps);
    private Textarea ExpectedResultArea => new(_driver, WrapperHelper.BuildTextAreaXpath(TestCaseProperties.ExpectedResult),
        TestCaseProperties.ExpectedResult);
    

    public void FillSteps(BaseTestCase testCase)
    {
        PreconditionsArea.SetValueAfterClick(((TextTestCase)testCase).Preconditions);
        StepsArea.SetValueAfterClick(((TextTestCase)testCase).Steps);
        ExpectedResultArea.SetValueAfterClick(((TextTestCase)testCase).ExpectedResult);
    }
}
