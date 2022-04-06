using OpenQA.Selenium;
using TestRailAutomationTest.Exception;
using TestRailAutomationTest.Logger;
using TestRailAutomationTest.Utils;

namespace TestRailAutomationTest.Page
{
    public class HomePage : BasePage
    {
        public const string PageName = "Home page";
        public static readonly By HeaderTitleLocation =
            By.XPath("//*[@id=\"content-header\"]//div[contains(text(),'All Projects')]");
        private static readonly By UserNameLocation =
            By.XPath("//*[@id=\"navigation-user\"]/span[@class=\"navigation-username\"]");
        private static readonly By AddProjectButtonLocation = By.Id("sidebar-projects-add");
        private const string ProjectExample = "ProjectName";
        private const string CommonProjectLocation = $"//a[text()='{ProjectExample}']";

        public HomePage(IWebDriver? driver) : base(driver)
        {
        }

        public void ClickAddProjectButton()
        {
            ClickButton(AddProjectButtonLocation);
            LoggerHelper.LogButtonClick("Add project");
        }

        public void OpenProject(string projectName)
        {
            try
            {
                ClickButton(By.XPath(CommonProjectLocation.Replace(ProjectExample, projectName)));
                LoggerHelper.LogButtonClick(projectName);
            }
            catch (WebDriverTimeoutException ex)
            {
                var message = $"Incorrect project {projectName}";
                LoggerSingleton.GetLogger().Error(message, ex);
                throw new IncorrectDataException(message);
            }
        }

        public string GetCurrentUserName() => Waits.WaitElementExistence(Driver, UserNameLocation).Text;
    }
}
