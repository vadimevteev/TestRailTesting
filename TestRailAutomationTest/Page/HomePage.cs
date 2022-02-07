using OpenQA.Selenium;

namespace TestRailAutomationTest.Page;

public class HomePage : BasePage
{
    
    public static readonly By HeaderTitleLocation = By.XPath("//*[@id=\"content-header\"]//div[contains(text(),'All Projects')]");
    public HomePage(IWebDriver driver) : base(driver)
    {
    }
}
