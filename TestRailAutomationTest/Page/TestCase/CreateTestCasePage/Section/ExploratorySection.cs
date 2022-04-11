using OpenQA.Selenium;
using TestRailAutomationTest.Model.TestCase;
using TestRailAutomationTest.Page.Constants;
using TestRailAutomationTest.WebElement.Service;
using TestRailAutomationTest.WebElement.Wrapper;

namespace TestRailAutomationTest.Page.TestCase.CreateTestCasePage.Section;

public class ExploratorySection
{
    private readonly IWebDriver? _driver;

    public ExploratorySection(IWebDriver? driver)
    {
        _driver = driver;
    }

    private Textarea MissionArea => new(_driver, SearchStrategy.TextareaXpath(TestCaseProperties.Mission),
        TestCaseProperties.Mission);

    private Textarea GoalsArea => new(_driver, SearchStrategy.TextareaXpath(TestCaseProperties.Goals),
        TestCaseProperties.Goals);

    public void FillSteps(BaseTestCase testCase)
    {
        MissionArea.SetValueAfterClick(((ExploratoryTestCase)testCase).Mission);
        GoalsArea.SetValueAfterClick(((ExploratoryTestCase)testCase).Goals);
    }
}
