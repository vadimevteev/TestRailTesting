using OpenQA.Selenium;
using TestRailAutomationTest.Model;
using TestRailAutomationTest.Utils;

namespace TestRailAutomationTest.Page
{

    public class LoginPage : BasePage
    {
        private readonly By _emailInputLocation = By.XPath("//*[@id=\"name\"]");
        private readonly By _passwordInputLocation = By.XPath("//*[@id=\"password\"]");
        private readonly By _errorMessageLocation = By.XPath("//*[@id=\"content\"]//div[@class=\"error-text\"]");

        public LoginPage(IWebDriver? driver) : base(driver)
        {
        }

        public LoginPage FillLoginForm(User user)
        {
            FillInput(_emailInputLocation, user.Email);
            FillInput(_passwordInputLocation, user.Password);
            return this;
        }

        private void FillInput(By inputLocation, string? data)
        {
            Waits.WaitElementExistence(Driver, inputLocation).SendKeys(data);
        }

        public LoginPage PressFindButton()
        {
            Waits.WaitElementExistence(Driver, SearchButtonLocation).Click();
            return this;
        }

        public string GetErrorMessageText()
        {
            return Waits.WaitElementExistence(Driver, _errorMessageLocation).Text;
        }
    }
}
