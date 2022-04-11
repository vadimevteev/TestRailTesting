using OpenQA.Selenium;
using TestRailAutomationTest.Utils;
using TestRailAutomationTest.WebElement.Service;
using TestRailAutomationTest.WebElement.Utils;

namespace TestRailAutomationTest.WebElement.Wrapper
{
    public class DropDown : BaseElementWrapper
    {
        private readonly string _label;

        private string ChooseValue(string value) => $"//div[@id=\"{_label}_chzn\"]//li[contains(text(),\"{value}\")]";
        
        public DropDown(IWebDriver? driver, string label, string name) : base(driver, SearchStrategy.DropDownXPath(label), name)
        {
            _label = label;
        }

        public void SelectValue(string value)
        {
            Element.Click();
            Waits.WaitElementExistence(Driver, By.XPath(ChooseValue(value))).Click();
            ActionsLogger.LogDropDownSelect(Name, value);
        }
    }
}
