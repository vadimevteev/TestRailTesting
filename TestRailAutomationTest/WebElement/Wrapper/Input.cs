using OpenQA.Selenium;
using TestRailAutomationTest.Utils;
using TestRailAutomationTest.WebElement.Service;
using TestRailAutomationTest.WebElement.Utils;

namespace TestRailAutomationTest.WebElement.Wrapper
{
    public class Input : BaseElementWrapper
    {
        public Input(IWebDriver? driver, string id, string name) : base(driver, SearchStrategy.Id(id), name)
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
}
