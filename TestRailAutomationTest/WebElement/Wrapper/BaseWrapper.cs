using OpenQA.Selenium;
using TestRailAutomationTest.Utils;

namespace TestRailAutomationTest.WebElement.Wrapper
{
    public abstract class BaseWrapper
    {
        private readonly By _elementPath;
        protected readonly IWebDriver? Driver;
        protected readonly string Name;

        protected IWebElement Element => Waits.WaitElementExistence(Driver, _elementPath);
        
        protected BaseWrapper(IWebDriver? driver, string elementPath, string name)
        {
            _elementPath = By.XPath(elementPath);
            Driver = driver;
            Name = name;
        }
    }
}
