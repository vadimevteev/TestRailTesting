using OpenQA.Selenium;

namespace TestRailAutomationTest.Page;

public abstract class BasePage
{
    protected readonly IWebDriver Driver;

    protected BasePage(IWebDriver driver)
    {
        Driver = driver;
    }
}
