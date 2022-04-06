using OpenQA.Selenium;
using TestRailAutomationTest.Utils;

namespace TestRailAutomationTest.Wrapper
{
    public class Input : BaseWrapper
    {
        public Input(IWebDriver? driver, string idName, string name) : base(driver, idName, name)
        {
        }

        public void SetValue(string? value)
        {
            Waits.WaitElementExistence(Driver, ElementId).SendKeys(value);
            LoggerHelper.LogInputValue(Name, value);
        } 

        public Input Click()
        {
            Waits.WaitElementExistence(Driver, ElementId).Click();
            return this;
        }
    }
}
