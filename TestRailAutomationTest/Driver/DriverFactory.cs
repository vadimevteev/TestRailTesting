using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using TestRailAutomationTest.Service;


namespace TestRailAutomationTest.Driver;

public class DriverFactory
{
    private static IWebDriver? _driver;

    public static IWebDriver GetDriver()
    {
        string currentBrowser = DataReader.GetConfig().Browser;
        if (_driver != null) return _driver;
        _driver = currentBrowser switch
        {
            "chrome" => new ChromeDriver(),
            "firefox" => new FirefoxDriver(),
            _ => new EdgeDriver()
        };
        _driver.Manage().Window.Maximize();

        return _driver;
    }
}
