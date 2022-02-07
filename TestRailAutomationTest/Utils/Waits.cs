using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestRailAutomationTest.Service;

namespace TestRailAutomationTest.Utils;

public static class Waits
{
    private static readonly TimeSpan DefaultWaitSeconds = TimeSpan.FromSeconds(DataReader.GetConfig().DefaultTimeoutSeconds);
    
    public static IWebElement WaitElementExistence(IWebDriver? driver, By elementPath)
    {
        return new WebDriverWait(driver, DefaultWaitSeconds)
            .Until(ExpectedConditions.ElementExists(elementPath));
    }
}
