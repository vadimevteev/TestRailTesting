using OpenQA.Selenium;
using TestRailAutomationTest.Logger;
using TestRailAutomationTest.Model;
using TestRailAutomationTest.Utils;
using TestRailAutomationTest.Wrapper;

namespace TestRailAutomationTest.Page
{
    public class LoginPage : BasePage
    {
        public const string PageName = "Login page";
        private const string EmailInputId = "name";
        private const string PasswordInputId = "password";
        private static readonly By ErrorMessageLocation = By.XPath("//*[@id=\"content\"]//div[@class=\"error-text\"]");

        public LoginPage(IWebDriver? driver) : base(driver)
        {
        }

        public LoginPage FillLoginForm(User user)
        {
            new Input(Driver,EmailInputId, "Email").SetValue(user.Email);
            new Input(Driver,PasswordInputId,"Password" ).SetValue(user.Password);
            return this;
        }

        public LoginPage PressFindButton()
        {
            ClickButton(SearchButtonLocation);
            Logging.LogButtonClick("Login");
            return this;
        }

        public string GetErrorMessageText()
        {
            return Waits.WaitElementExistence(Driver, ErrorMessageLocation).Text;
        }
    }
}
