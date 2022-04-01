using OpenQA.Selenium;

namespace TestRailAutomationTest.Wrapper
{
    public abstract class BaseWrapper
    {
        protected readonly By ElementId;
        protected const string Example = "EXAMPLE";
        protected readonly IWebDriver? Driver;
        protected string Name;
        
        protected BaseWrapper(IWebDriver? driver, string elementId, string name)
        {
            ElementId = By.Id(elementId);
            Driver = driver;
            Name = name;
        }
    }
}
