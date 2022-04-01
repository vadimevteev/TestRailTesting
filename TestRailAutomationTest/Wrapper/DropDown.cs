using OpenQA.Selenium;
using TestRailAutomationTest.Utils;

namespace TestRailAutomationTest.Wrapper
{
    public class DropDown : BaseWrapper
    {
        private const string CommonPropertyId = $"{Example}_chzn";

        public DropDown(IWebDriver? driver, string elementPartId) : base(driver, CommonPropertyId.Replace(Example,elementPartId))
        {
        }

        public void SelectValue(string value)
        {
            var valueXpath = $"//div[@id=\"{ElementId.Criteria[1..]}\"]//li[contains(text(),\"{value}\")]";
            Waits.WaitElementExistence(Driver, ElementId).Click();
            Waits.WaitElementExistence(Driver, By.XPath(valueXpath)).Click();
        }
    }
}
