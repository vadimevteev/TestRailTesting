using OpenQA.Selenium;
using TestRailAutomationTest.Utils;
using TestRailAutomationTest.WebElement.Service;

namespace TestRailAutomationTest.WebElement.Wrapper;

public class ButtonLink : BaseWrapper
{
    public ButtonLink(IWebDriver? driver, string xpath, string name) : base(driver, xpath, name)
    {
    }

    public void Click()
    {
        Waits.WaitElementExistence(Driver, ElementPath).Click();
        //LoggerHelper.LogButtonClick(Name);
    }
}
