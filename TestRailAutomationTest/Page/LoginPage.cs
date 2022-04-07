using OpenQA.Selenium;
using TestRailAutomationTest.Model;
using TestRailAutomationTest.Utils;
using TestRailAutomationTest.WebElement.Wrapper;

namespace TestRailAutomationTest.Page
{
    public class LoginPage : BasePage
    {
        public const string PageName = "Login page";
        private const string EmailInputId = "name";
        private const string PasswordInputId = "password";
        private static readonly By ErrorMessageLocation = By.XPath("//*[@id=\"content\"]//div[@class=\"error-text\"]");

        private Button SearchButton => new(Driver, LogInButtonId, "Log In");
        private Input EmailInput => new(Driver, EmailInputId, "Email");
        private Input PasswordInput => new(Driver, PasswordInputId, "Password");

        public LoginPage(IWebDriver? driver) : base(driver)
        {
        }

        public LoginPage FillLoginForm(User user)
        {
            EmailInput.SetValue(user.Email);
            PasswordInput.SetValue(user.Password);
            return this;
        }

        public LoginPage PressFindButton()
        {
            SearchButton.Click();
            return this;
        }

        public string GetErrorMessageText()
        {
            return Waits.WaitElementExistence(Driver, ErrorMessageLocation).Text;
        }
    }
}
