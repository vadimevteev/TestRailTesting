using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestProject;

public class Tests
{
    private IWebDriver driver;
    private readonly string HOME_PAGE_URL = "https://vadimevteev.testrail.io/";
    
    [SetUp]
    public void Start()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
    }
    
    [Test]
    public void Test()
    {
        driver.Url = HOME_PAGE_URL;
        Assert.True(driver.Url.Contains(HOME_PAGE_URL));
    }

    [TearDown]
    public void Close()
    {
         driver.Quit();
    }
}