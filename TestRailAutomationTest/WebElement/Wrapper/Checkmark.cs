using OpenQA.Selenium;
using TestRailAutomationTest.Utils;
using TestRailAutomationTest.WebElement.Service;

namespace TestRailAutomationTest.WebElement.Wrapper;

public class Checkmark : BaseWrapper
{
    public Checkmark(IWebDriver? driver, string id, string name) : base(driver, WrapperHelper.BuildIdXpath(id), name)
    {
    }
    
    public void Click()
    {
        Element.Click();
        LoggerHelper.LogCheckboxClick(Name);
    }
}
