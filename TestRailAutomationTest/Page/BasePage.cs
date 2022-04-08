using System;
using OpenQA.Selenium;
using TestRailAutomationTest.Exception;
using TestRailAutomationTest.Logger;
using TestRailAutomationTest.Service;
using TestRailAutomationTest.Test;
using TestRailAutomationTest.Utils;

namespace TestRailAutomationTest.Page
{
    public abstract class BasePage
    {
        protected readonly IWebDriver? Driver;
        protected const string Label = "LABEL";
        public static readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(DataReader.GetConfig().DefaultTimeoutSeconds);
        protected static readonly TimeSpan ReducedTimeout = TimeSpan.FromSeconds(DataReader.GetConfig().ReducedTimeoutSeconds);
        protected const string LogInButtonId = "button_primary";
        
        protected BasePage(IWebDriver? driver)
        {
            Driver = driver;
        }

        public void OpenStartPage()
        {
            Driver!.Url = BaseTest.LoginPageUrl;
            WaitForOpen(LoginPage.PageName, By.Id(LogInButtonId));
        }

        protected string GetTextFromElement(By elementPath) => Waits.WaitElementExistence(Driver, elementPath).Text;

        public void WaitForOpen(string pageName, By uniqueElementLocation)
        {
            if (!IsElementExistOnPage(uniqueElementLocation))
            {
                throw new PageNotOpenedException($"\"{pageName}\" was not opened");
            }
            LoggerSingleton.GetLogger().Info($"Page \"{pageName}\" - opened");
        }
        
        protected static string ReplaceValue(string commonValue, string value) => commonValue.Replace(Label, value);

        public bool IsElementExistOnPage(By elementLocation) => IsElementExistOnPage(elementLocation, DefaultTimeout);

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
