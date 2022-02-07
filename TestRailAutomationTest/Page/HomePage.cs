using OpenQA.Selenium;
using TestRailAutomationTest.Utils;

namespace TestRailAutomationTest.Page;

public class HomePage : BasePage
{
    
    public static readonly By HeaderTitleLocation = By.XPath("//*[@id=\"content-header\"]//div[contains(text(),'All Projects')]");
    private static readonly By UserNameLocation =
        By.XPath("//*[@id=\"navigation-user\"]/span[@class=\"navigation-username\"]");
    
    public HomePage(IWebDriver? driver) : base(driver)
    {
    }

    public string GetCurrentUserName()
    {
        return Waits.WaitElementExistence(Driver, UserNameLocation).Text;
    }
}
