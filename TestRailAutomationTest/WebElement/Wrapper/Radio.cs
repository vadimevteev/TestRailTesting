using OpenQA.Selenium;
using TestRailAutomationTest.Utils;
using TestRailAutomationTest.WebElement.Service;
using TestRailAutomationTest.WebElement.Utils;

namespace TestRailAutomationTest.WebElement.Wrapper
{
    public class Radio : BaseElementWrapper
    {
        public Radio(IWebDriver? driver, string id, string name) : base(driver, SearchStrategy.Id(id), name)
        {
        }

        public void Click()
        {
            Element.Click();
            ActionsLogger.LogRadioClick(Name);
        }
    }
}
