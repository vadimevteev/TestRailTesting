using System.Collections.Generic;
using OpenQA.Selenium;
using TestRailAutomationTest.Utils;

namespace TestRailAutomationTest.Page
{

    public class HomePage : BasePage
    {

        public static readonly By HeaderTitleLocation =
            By.XPath("//*[@id=\"content-header\"]//div[contains(text(),'All Projects')]");

        private static readonly By UserNameLocation =
            By.XPath("//*[@id=\"navigation-user\"]/span[@class=\"navigation-username\"]");

        private static readonly By AddProjectButtonLocation = By.XPath("//a[@id=\"sidebar-projects-add\"]");

        public HomePage(IWebDriver? driver) : base(driver)
        {
        }

        public HomePage ClickAddProjectButton()
        {
            ClickButton(AddProjectButtonLocation);
            return this;
        }

        public string GetCurrentUserName()
        {
            return Waits.WaitElementExistence(Driver, UserNameLocation).Text;
        }
    }
}
