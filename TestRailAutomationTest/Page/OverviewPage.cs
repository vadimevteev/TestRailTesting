using OpenQA.Selenium;

namespace TestRailAutomationTest.Page;

public class OverviewPage : BasePage
{
    private const string ProjectNameLocation = "//div[@id=\"content-inner\"]//a[text()='ProjectName']";

    public OverviewPage(IWebDriver? driver) : base(driver)
    {
    }
    
    public bool IsProjectExists(string projectName)
    {
        return IsElementExistOnPage(By.XPath(ProjectNameLocation.Replace("ProjectName", projectName)));
    }
}
