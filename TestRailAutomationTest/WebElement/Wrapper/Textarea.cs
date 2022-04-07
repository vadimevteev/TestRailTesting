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
        Waits.WaitElementExistence(Driver, ElementPath).SendKeys(value);
        LoggerHelper.LogInputValue(Name, value);
    } 

    public Textarea Click()
    {
        Waits.WaitElementExistence(Driver, ElementPath).Click();
        return this;
    }

    public void SetValueAfterClick(string? value)
    {
        Waits.WaitElementExistence(Driver, ElementPath).Click();
        SetValue(value);
    }
}
