using OpenQA.Selenium;

namespace TestRailAutomationTest.Page.Project
{
    public class TestCasesMenuPage : BasePage
    {
        public const string PageName = "Test Cases page";

        public static readonly By HeaderTitleLocation =
            By.XPath("//div[@id=\"content-header\"]//div[contains(text(),'Test Cases')]");
        private static readonly By AddTestCaseButtonLocation = By.Id("sidebar-cases-add");

        public TestCasesMenuPage(IWebDriver? driver) : base(driver)
        {
        }

        public void AddTestCase() => ClickButton(AddTestCaseButtonLocation);
    }
}
