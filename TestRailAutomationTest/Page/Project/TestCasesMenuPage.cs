using OpenQA.Selenium;
using TestRailAutomationTest.WebElement.Wrapper;

namespace TestRailAutomationTest.Page.Project
{
    public class TestCasesMenuPage : BasePage
    {
        public const string PageName = "Test Cases page";

        public static readonly By HeaderTitleLocation =
            By.XPath("//div[@id=\"content-header\"]//div[contains(text(),'Test Cases')]");
        private const string AddTestCaseButtonId = "sidebar-cases-add";

        private Button AddTestCaseButton => new(Driver, AddTestCaseButtonId, "Add test case");

        public TestCasesMenuPage(IWebDriver? driver) : base(driver)
        {
        }

        public void AddTestCase() => AddTestCaseButton.Click();
    }
}
