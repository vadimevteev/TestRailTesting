using OpenQA.Selenium;

namespace TestRailAutomationTest.Page
{
    public class ProjectsMenuPage : BasePage
    {
        public const string PageName = "Projects overview page";
        private static readonly By HomePageLinkLocation = By.XPath("//a[@id=\"navigation-dashboard\"]");

        public static readonly By MenuProjectItemSelected =
            By.XPath("//a[@id=\"navigation-sub-projects\"]/ancestor::li[contains(@class,\"menu-item-selected\")]");

        public ProjectsMenuPage(IWebDriver? driver) : base(driver)
        {
        }

        public void OpenHomePage() => ClickButton(HomePageLinkLocation);
    }
}
