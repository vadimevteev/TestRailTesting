using OpenQA.Selenium;
using TestRailAutomationTest.WebElement.Wrapper;

namespace TestRailAutomationTest.Page
{
    public class ProjectsMenuPage : BasePage
    {
        public const string PageName = "Projects overview page";
        private const string DashboardButtonId = "navigation-dashboard";
        public static readonly By MenuProjectItemSelected =
            By.XPath("//a[@id=\"navigation-sub-projects\"]/ancestor::li[contains(@class,\"menu-item-selected\")]");

        private Button DashboardButton => new(Driver, DashboardButtonId, "Dashboard");

        public ProjectsMenuPage(IWebDriver? driver) : base(driver)
        {
        }

        public void OpenHomePage() => DashboardButton.Click();
    }
}
