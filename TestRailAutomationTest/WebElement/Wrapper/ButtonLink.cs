using OpenQA.Selenium;
using TestRailAutomationTest.Utils;

namespace TestRailAutomationTest.WebElement.Wrapper;

public class ButtonLink : BaseWrapper
{
    public ButtonLink(IWebDriver? driver, string xpath, string name) : base(driver, xpath, name)
    {
    }

    public void Click()
    {
        Element.Click();
        LoggerHelper.LogButtonLinkClick(Name);
    }
}
