using OpenQA.Selenium;
using TestRailAutomationTest.Model;
using TestRailAutomationTest.Service;
using TestRailAutomationTest.Utils;

namespace TestRailAutomationTest.Page;

public class LoginPage : BasePage
{
    private readonly string _pageUrl = DataReader.GetConfig().HomePageUrl;
    private readonly By _emailInputLocation = By.XPath("//*[@id=\"name\"]");
    private readonly By _passwordInputLocation = By.XPath("//*[@id=\"password\"]");
    private readonly By _searchButtonLocation = By.XPath("//button[contains(@class,\"loginpage-button\")]");
    
    public LoginPage(IWebDriver driver) : base(driver)
    {
        
    }

    public LoginPage OpenPage()
    {
        Driver.Navigate().GoToUrl(_pageUrl);
        Waits.WaitElementExistence(Driver, _searchButtonLocation);
        return this;
    }

    public LoginPage FillLoginForm(User user)
    {
        FillInput(_emailInputLocation, user.Email);
        FillInput(_passwordInputLocation, user.Password);
        return this;
    }

    private void FillInput(By inputLocation, string data)
    {
        Waits.WaitElementExistence(Driver, inputLocation).SendKeys(data);
    }

    public LoginPage PressFindButton()
    {
        Waits.WaitElementExistence(Driver, _searchButtonLocation).Click();
        return this;
    }
}
