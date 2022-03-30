using System;
using OpenQA.Selenium;

namespace TestRailAutomationTest.Wrapper
{
    public abstract class BaseWrapper
    {
        protected readonly By ElementId;
        protected const string Example = "EXAMPLE";
        protected readonly IWebDriver? Driver;
        
        protected BaseWrapper(IWebDriver? driver, string elementId)
        {
            ElementId = By.Id(elementId);
            Driver = driver;
        }
    }
}
