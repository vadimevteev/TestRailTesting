using OpenQA.Selenium;
using TestRailAutomationTest.Utils;
using TestRailAutomationTest.WebElement.Service;

namespace TestRailAutomationTest.WebElement.Wrapper
{
    public class DropDown : BaseWrapper
    {
        private readonly string _label;
        
        public DropDown(IWebDriver? driver, string label, string name) : base(driver, WrapperHelper.BuildDropDownXPath(label), name)
        {
            _label = label;
        }

        public void SelectValue(string value)
        {
            var valueXpath = $"//div[@id=\"{_label}_chzn\"]//li[contains(text(),\"{value}\")]";
            Waits.WaitElementExistence(Driver, ElementPath).Click();
            Waits.WaitElementExistence(Driver, By.XPath(valueXpath)).Click();
            LoggerHelper.LogDropDownSelect(Name, value);
        }
    }
}
