using OpenQA.Selenium;
using TestRailAutomationTest.Utils;
using TestRailAutomationTest.WebElement.Service;
using TestRailAutomationTest.WebElement.Utils;

namespace TestRailAutomationTest.WebElement.Wrapper
{
    public class Button : BaseElementWrapper
    {
        public Button(IWebDriver? driver, string id, string name) : base(driver, SearchStrategy.Id(id), name)
        {
        }

        public void Click()
        {
            Element.Click();
            ActionsLogger.LogButtonClick(Name);
        }
    }
}
