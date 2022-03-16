using OpenQA.Selenium;
using TestRailAutomationTest.Model;
using TestRailAutomationTest.Utils;

namespace TestRailAutomationTest.Page
{
    public class LoginPage : BasePage
    {
        public const string PageName = "Login page";
        private static readonly By EmailInputLocation = By.Id("name");
        private static readonly By PasswordInputLocation = By.Id("password");
        private static readonly By ErrorMessageLocation = By.XPath("//*[@id=\"content\"]//div[@class=\"error-text\"]");

        public LoginPage(IWebDriver? driver) : base(driver)
        {
        }

        public LoginPage FillLoginForm(User user)
        {
            FillInput(EmailInputLocation, user.Email);
            FillInput(PasswordInputLocation, user.Password);
            return this;
        }

        public LoginPage PressFindButton()
        {
            ClickButton(SearchButtonLocation);
            return this;
        }

        public string GetErrorMessageText()
        {
            return Waits.WaitElementExistence(Driver, ErrorMessageLocation).Text;
        }
    }
}
