using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using TestRailAutomationTest.Service;


namespace TestRailAutomationTest.Driver;

public static class DriverFactory
{
    private const string EdgeBrowser = "edge";
    private const string FirefoxBrowser = "firefox";
    
    public static IWebDriver GetDriver()
    {
        var currentBrowser = DataReader.GetConfig().Browser;
        IWebDriver driver = currentBrowser switch
        {
            EdgeBrowser => new EdgeDriver(),
            FirefoxBrowser => new FirefoxDriver(),
            _ => new ChromeDriver()
        };
        driver.Manage().Window.Maximize();

        return driver;
    }
}
