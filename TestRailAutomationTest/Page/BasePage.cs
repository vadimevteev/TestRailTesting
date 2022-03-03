using System;
using OpenQA.Selenium;
using TestRailAutomationTest.Exception;
using TestRailAutomationTest.Service;
using TestRailAutomationTest.Test;
using TestRailAutomationTest.Utils;

namespace TestRailAutomationTest.Page
{

    public abstract class BasePage
    {
        protected readonly IWebDriver? Driver;
        protected const string Example = "EXAMPLE";
        public static readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(DataReader.GetConfig().DefaultTimeoutSeconds);
        protected static readonly TimeSpan ReducedTimeout = TimeSpan.FromSeconds(DataReader.GetConfig().ReducedTimeoutSeconds);
        protected static readonly By SearchButtonLocation = By.XPath("//button[contains(@class,\"loginpage-button\")]");
        
        protected BasePage(IWebDriver? driver)
        {
            Driver = driver;
        }

        public void OpenStartPage()
        {
            Driver!.Url = BaseTest.LoginPageUrl;
            WaitForOpen(LoginPage.PageName, SearchButtonLocation);
        }
    
        protected void FillInput(By inputLocation, string? data)
        {
            Waits.WaitElementExistence(Driver, inputLocation).SendKeys(data);
        }

        protected void ClickButton(By buttonLocation)
        {
            Waits.WaitElementExistence(Driver,buttonLocation).Click();
        }

        protected void FillInputAfterClick(By inputLocation, string? data)
        {
            ClickButton(inputLocation);
            FillInput(inputLocation, data);
        }

        protected string GetTextFromElement(By elementPath)
        {
            return Waits.WaitElementExistence(Driver, elementPath).Text;
        }

        public void WaitForOpen(string pageName, By uniqueElementLocation)
        {
            if (!IsElementExistOnPage(uniqueElementLocation))
            {
                throw new PageNotOpenedException($"{pageName} was not opened");
            }
        }
        
        protected static By GetElementLocation(string commonLocation, string value)
        {
            return By.XPath(commonLocation.Replace(Example, value));
        }

        public bool IsElementExistOnPage(By elementLocation)
        {
            return IsElementExistOnPage(elementLocation, DefaultTimeout);
        }

        protected bool IsElementExistOnPage(By elementLocation, TimeSpan waitSeconds)
        {
            try
            {
                Waits.WaitElementExistence(Driver, elementLocation, waitSeconds);
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

    }
}
