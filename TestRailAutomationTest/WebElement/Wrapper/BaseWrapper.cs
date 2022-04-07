using OpenQA.Selenium;

namespace TestRailAutomationTest.WebElement.Wrapper
{
    public abstract class BaseWrapper
    {
        protected readonly By ElementPath;
        protected readonly IWebDriver? Driver;
        protected readonly string Name;
        
        
        protected BaseWrapper(IWebDriver? driver, string elementPath, string name)
        {
            ElementPath = By.XPath(elementPath);
            Driver = driver;
            Name = name;
        }
    }
}
