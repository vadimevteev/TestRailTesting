using OpenQA.Selenium;
using TestRailAutomationTest.Utils;
using TestRailAutomationTest.WebElement.Service;

namespace TestRailAutomationTest.WebElement.Wrapper
{
    public class Input : BaseWrapper
    {
        public Input(IWebDriver? driver, string id, string name) : base(driver, WrapperHelper.BuildIdXpath(id), name)
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
}
