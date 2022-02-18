using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestRailAutomationTest.Page;

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

        public static IEnumerable<IWebElement> WaitAllElementsExistence(IWebDriver? driver, By elementPath)
        {
            return new WebDriverWait(driver, BasePage.DefaultTimeout)
                .Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(elementPath));
        }
    }
}
