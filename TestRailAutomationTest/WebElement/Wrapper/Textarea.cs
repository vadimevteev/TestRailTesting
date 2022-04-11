using OpenQA.Selenium;
using TestRailAutomationTest.Utils;

namespace TestRailAutomationTest.WebElement.Wrapper;

public class Textarea : BaseWrapper
{
    public Textarea(IWebDriver? driver, string xpath, string name) : base(driver, xpath, name)
    {
    }

    public void SetValue(string? value)
    {
        Element.SendKeys(value);
        LoggerHelper.LogInputValue(Name, value);
    }

    public void SetValueAfterClick(string? value)
    {
        Element.Click();
        SetValue(value);
    }
}
