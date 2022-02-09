using OpenQA.Selenium;
using TestRailAutomationTest.Exception;
using TestRailAutomationTest.Service;
using TestRailAutomationTest.Utils;

namespace TestRailAutomationTest.Page
{

    public abstract class BasePage
    {
        protected readonly IWebDriver? Driver;
        private static readonly string LoginPageUrl = DataReader.GetConfig().AppUrl;
        protected static readonly By SearchButtonLocation = By.XPath("//button[contains(@class,\"loginpage-button\")]");

        protected BasePage(IWebDriver? driver)
        {
            Driver = driver;
        }

        public void OpenStartPage()
        {
            Driver!.Url = LoginPageUrl;
            WaitForOpen(SearchButtonLocation);
        }

        protected void FillInput(By inputLocation, string? data)
        {
            Waits.WaitElementExistence(Driver, inputLocation).SendKeys(data);
        }

        protected void ClickButton(By buttonLocation)
        {
            Waits.WaitElementExistence(Driver,buttonLocation).Click();
        }

        public void WaitForOpen(By uniqueElementLocation)
        {
            if (!IsPageOpened(uniqueElementLocation))
            {
                throw new PageNotOpenedException("Current page was not opened");
            }
        }

        public bool IsPageOpened(By uniqueElementLocation)
        {
            try
            {
                Waits.WaitElementExistence(Driver, uniqueElementLocation);
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}
