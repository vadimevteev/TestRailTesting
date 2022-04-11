using OpenQA.Selenium;
using TestRailAutomationTest.Utils;
using TestRailAutomationTest.WebElement.Utils;

namespace TestRailAutomationTest.WebElement.Wrapper;

public class Textarea : BaseElementWrapper
{
    public Textarea(IWebDriver? driver, string xpath, string name) : base(driver, xpath, name)
    {
    }

    public void SetValue(string? value)
    {
        Element.SendKeys(value);
        ActionsLogger.LogInputValue(Name, value);
    }

    public void SetValueAfterClick(string? value)
    {
        Element.Click();
        SetValue(value);
    }
}
