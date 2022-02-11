using OpenQA.Selenium;

namespace TestRailAutomationTest.Page;

public class OverviewPage : BasePage
{
    private const string ProjectNameLocation = "//div[@id=\"content-inner\"]//a[text()='ProjectName']";
    private static readonly By HomePageLinkLocation = By.XPath("//a[@id=\"navigation-dashboard\"]");

    public OverviewPage(IWebDriver? driver) : base(driver)
    {
    }

    public OverviewPage GoToHomePage()
    {
        ClickButton(HomePageLinkLocation);
        return this;
    }
    
    public bool IsProjectExists(string projectName)
    {
        return IsElementExistOnPage(By.XPath(ProjectNameLocation.Replace("ProjectName", projectName)));
    }
}
