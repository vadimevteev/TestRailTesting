using System.Linq;
using OpenQA.Selenium;
using TestRailAutomationTest.Exception;
using TestRailAutomationTest.Model.TestCase;
using TestRailAutomationTest.Page.Constants;

namespace TestRailAutomationTest.Page.Project
{
    public class CreateTestCasePage : BasePage
    {
        public const string PageName = "Add test case page";
        private const string PropertyValueExample = "EXAMPL_VALUE";
        public static readonly By HeaderTitleLocation =
            By.XPath("//*[@id=\"content-header\"]//div[contains(text(),'Add Test Case')]");
        
        private const string CommonInputLocation = $"//input[@id=\"{Example}\"]";
        private const string CommonDescriptionInputLocation = $"//div[@id=\"custom_{Example}_display\"]";
        private const string CommonProperty = $"//div[@id=\"{Example}_chzn\"]";
        private const string CommonPropertyListLocation = $"{CommonProperty}/a";
        private const string CommonPropertyValueLocation = $"{CommonProperty}//li[contains(text(),'{PropertyValueExample}')]";
        
        private static readonly By AddTestCaseButton =
            By.XPath("//div[@id=\"custom_steps_separated_container\"]//a[@class=\"addStep\"]");
        private static readonly By StepDescriptionInputLocation =
            By.XPath("//td[@class=\"step-content\"]//div[@placeholder=\"Step Description\"]");
        private static readonly By StepExpectedResultInputLocation =
            By.XPath("//td[@class=\"step-content\"]//div[@placeholder=\"Expected Result\"]");
        private static readonly By AcceptButtonLocation = By.Id("accept");

        public CreateTestCasePage(IWebDriver? driver) : base(driver)
        {
        }

        public void FillTestCaseForm(BaseTestCase testCase)
        {
            FillInputAfterClick(GetElementLocation(CommonInputLocation, TestCaseProperties.Title), testCase.Title);
            ChoosePropertyValue(TestCaseProperties.Template, testCase.Template);
            ChooseType(testCase);
            ChoosePropertyValue(TestCaseProperties.Section, testCase.Section);
            ChoosePropertyValue(TestCaseProperties.Priority, testCase.Priority);
            FillOptionalFields(testCase);
        }

        private void ChooseType(BaseTestCase testCase)
        {
            try
            {
                ChoosePropertyValue(TestCaseProperties.Type, testCase.Type);
            }
            catch (StaleElementReferenceException)
            {
                ChooseType(testCase);
            }
        }

        private void FillOptionalFields(BaseTestCase testCase)
        {
            if (testCase is DefaultTestCase)
            {
                return;
            }
            
            FillInputAfterClick(GetElementLocation(CommonInputLocation, TestCaseProperties.Estimate),
                testCase.Estimate.ToString());
            FillInputAfterClick(GetElementLocation(CommonInputLocation, TestCaseProperties.References),
                testCase.References);
            ChoosePropertyValue(TestCaseProperties.AutomationType, 
                testCase.AutomationType ?? TestCaseData.AutomationType.FirstOrDefault()!);
            FillDescription(testCase);
        }

        private void FillDescription(BaseTestCase testCase)
        {
            switch (testCase.Template)
            {
                case TestCaseData.ExploratoryTemplate:
                    FillInputAfterClick(GetElementLocation(CommonDescriptionInputLocation, TestCaseProperties.Mission),
                        ((ExploratoryTestCase) testCase).Mission);
                    FillInputAfterClick(GetElementLocation(CommonDescriptionInputLocation, TestCaseProperties.Goals),
                        ((ExploratoryTestCase) testCase).Goals);
                    break;

                case TestCaseData.StepsTemplate:
                    FillInputAfterClick(
                        GetElementLocation(CommonDescriptionInputLocation, TestCaseProperties.Preconditions),
                        ((StepsTestCase) testCase).Preconditions);
                    ClickButton(AddTestCaseButton);
                    FillInputAfterClick(StepDescriptionInputLocation, ((StepsTestCase) testCase).StepDescription);
                    FillInputAfterClick(StepExpectedResultInputLocation, ((StepsTestCase) testCase).StepExpectedResult);
                    break;

                case TestCaseData.TextTemplate:
                    FillInputAfterClick(
                        GetElementLocation(CommonDescriptionInputLocation, TestCaseProperties.Preconditions),
                        ((TextTestCase) testCase).Preconditions);
                    FillInputAfterClick(GetElementLocation(CommonDescriptionInputLocation, TestCaseProperties.Steps),
                        ((TextTestCase) testCase).Steps);
                    FillInputAfterClick(
                        GetElementLocation(CommonDescriptionInputLocation, TestCaseProperties.ExpectedResult),
                        ((TextTestCase) testCase).ExpectedResult);
                    break;
                default:
                    throw new IncorrectDataException($"{testCase.Template} type is incorrect");
            }
        }

        private void ChoosePropertyValue(string propertyName, string value)
        {
            ClickButton(GetElementLocation(CommonPropertyListLocation, propertyName));
            ClickButton(FindPropertyValue(propertyName, value));
        }

        private static By FindPropertyValue(string propertyName, string value) 
            => By.XPath(CommonPropertyValueLocation.Replace(Example, propertyName)
                .Replace(PropertyValueExample, value));

        public void ClickAcceptButton() => ClickButton(AcceptButtonLocation);
    }
}
