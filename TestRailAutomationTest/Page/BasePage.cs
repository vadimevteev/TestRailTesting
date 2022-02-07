using OpenQA.Selenium;
using TestRailAutomationTest.Utils;

namespace TestRailAutomationTest.Page;

public abstract class BasePage
{
    protected readonly IWebDriver Driver;

    protected BasePage(IWebDriver driver)
    {
        Driver = driver;
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
