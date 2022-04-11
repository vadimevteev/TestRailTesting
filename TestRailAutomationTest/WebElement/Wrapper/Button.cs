using OpenQA.Selenium;
using TestRailAutomationTest.Utils;
using TestRailAutomationTest.WebElement.Service;

namespace TestRailAutomationTest.WebElement.Wrapper;

public class Button : BaseWrapper
{
    public Button(IWebDriver? driver, string id, string name) : base(driver, WrapperHelper.BuildIdXpath(id), name)
    {
    }

    public void Click()
    {
        Element.Click();
        LoggerHelper.LogButtonClick(Name);
    }
}
