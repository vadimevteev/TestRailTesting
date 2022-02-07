using OpenQA.Selenium;
using TestRailAutomationTest.Service;
using TestRailAutomationTest.Utils;

namespace TestRailAutomationTest.Page;

public abstract class BasePage
{
    protected readonly IWebDriver? Driver;
    private readonly string _loginPageUrl = DataReader.GetConfig().AppUrl;
    protected readonly By SearchButtonLocation = By.XPath("//button[contains(@class,\"loginpage-button\")]");

    protected BasePage(IWebDriver? driver)
    {
        Driver = driver;
    }
    
    public void OpenStartPage()
    {
        Driver!.Url = _loginPageUrl;
        Waits.WaitElementExistence(Driver, SearchButtonLocation);
    }
    
    public bool IsPageOpened(By uniqueElementLocation)
    {
        try
        {
            Waits.WaitElementExistence(Driver, uniqueElementLocation);
            return true;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }
}
