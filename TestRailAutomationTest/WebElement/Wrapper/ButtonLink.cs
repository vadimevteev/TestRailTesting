using OpenQA.Selenium;
using TestRailAutomationTest.Utils;
using TestRailAutomationTest.WebElement.Utils;

namespace TestRailAutomationTest.WebElement.Wrapper
{
    public class ButtonLink : BaseElementWrapper
    {
        public ButtonLink(IWebDriver? driver, string xpath, string name) : base(driver, xpath, name)
        {
        }

        public void Click()
        {
            Element.Click();
            ActionsLogger.LogButtonLinkClick(Name);
        }
    }
}
