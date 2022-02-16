using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestRailAutomationTest.Page;
using TestRailAutomationTest.Page.Project;

namespace TestRailAutomationTest.Utils
{

    public static class Waits
    {
        public static IWebElement WaitElementExistence(IWebDriver? driver, By elementPath)
        {
            return WaitElementExistence(driver, elementPath, BasePage.DefaultTimeout);
        }
        
        public static IWebElement WaitElementExistence(IWebDriver? driver, By elementPath, TimeSpan waitSeconds)
        {
            return new WebDriverWait(driver, waitSeconds)
                .Until(ExpectedConditions.ElementExists(elementPath));
        }
    }
}
