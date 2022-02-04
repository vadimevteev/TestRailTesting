using OpenQA.Selenium;
using TestRailAutomationTest.Utils;

namespace TestRailAutomationTest.Page;

public class HomePage : BasePage
{
    
    private readonly By _headerTitleLocation = By.XPath("//*[@id=\"content-header\"]//div[contains(text(),'All Projects')]");
    public HomePage(IWebDriver driver) : base(driver)
    {
        
    }

    public HomePage OpenPage()
    {
        Waits.WaitElementExistence(Driver, _headerTitleLocation);
        return this;
    }

    public bool IsPageOpened()
    {
        try
        {
            OpenPage();
            return true;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }
}
