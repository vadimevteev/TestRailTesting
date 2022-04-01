using System.Linq;
using OpenQA.Selenium;
using TestRailAutomationTest.Exception;
using TestRailAutomationTest.Logger;
using TestRailAutomationTest.Model.TestCase;
using TestRailAutomationTest.Page.Constants;
using TestRailAutomationTest.Wrapper;

namespace TestRailAutomationTest.Page.Project
{
    public class CreateTestCasePage : BasePage
    {
        public const string PageName = "Add test case page";
        public static readonly By HeaderTitleLocation =
            By.XPath("//*[@id=\"content-header\"]//div[contains(text(),'Add Test Case')]");

        private const string CommonDescriptionId = $"custom_{Example}_display";
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
            new Input(Driver, TestCaseProperties.Title,"Title").Click().SetValue(testCase.Title);
            new DropDown(Driver,TestCaseProperties.Template,"Template" ).SelectValue(testCase.Template);
            ChooseType(testCase);
            new DropDown(Driver,TestCaseProperties.Section, "Section").SelectValue(testCase.Section);
            new DropDown(Driver,TestCaseProperties.Priority, "Priority").SelectValue(testCase.Priority);
            FillOptionalFields(testCase);
        }

        private void ChooseType(BaseTestCase testCase)
        {
            try
            {
                new DropDown(Driver,TestCaseProperties.Type, "Type").SelectValue(testCase.Type);
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
            
            new Input(Driver, TestCaseProperties.Estimate, "Estimate").Click().SetValue(testCase.Estimate.ToString());
            new Input(Driver, TestCaseProperties.References, "References").Click().SetValue(testCase.References);
            new DropDown(Driver,TestCaseProperties.AutomationType, "Automation type")
                .SelectValue(testCase.AutomationType ?? TestCaseData.AutomationType.FirstOrDefault()!);
            FillDescription(testCase);
        }

        private void FillDescription(BaseTestCase testCase)
        {
            switch (testCase.Template)
            {
                case TestCaseData.ExploratoryTemplate:
                    new Input(Driver, ReplaceValue(CommonDescriptionId, TestCaseProperties.Mission), "Mission")
                        .Click().SetValue(((ExploratoryTestCase) testCase).Mission);
                    new Input(Driver, ReplaceValue(CommonDescriptionId, TestCaseProperties.Goals), "Goals")
                        .Click().SetValue(((ExploratoryTestCase) testCase).Goals);
                    break;

                case TestCaseData.StepsTemplate:
                    new Input(Driver, ReplaceValue(CommonDescriptionId, TestCaseProperties.Preconditions), "Preconditions")
                        .Click().SetValue(((StepsTestCase) testCase).Preconditions);
                    ClickButton(AddTestCaseButton);
                    FillInputAfterClick(StepDescriptionInputLocation, ((StepsTestCase) testCase).StepDescription);
                    Logging.LogInputValue("Step description", ((StepsTestCase) testCase).StepDescription);
                    FillInputAfterClick(StepExpectedResultInputLocation, ((StepsTestCase) testCase).StepExpectedResult);
                    Logging.LogInputValue("Expected result", ((StepsTestCase) testCase).StepExpectedResult);
                    break;

                case TestCaseData.TextTemplate:
                    new Input(Driver, ReplaceValue(CommonDescriptionId, TestCaseProperties.Preconditions), "Preconditions")
                        .Click().SetValue(((TextTestCase) testCase).Preconditions);
                    new Input(Driver, ReplaceValue(CommonDescriptionId, TestCaseProperties.Steps), "Steps")
                        .Click().SetValue(((TextTestCase) testCase).Steps);
                    new Input(Driver, ReplaceValue(CommonDescriptionId, TestCaseProperties.ExpectedResult), "Expected result")
                        .Click().SetValue(((TextTestCase) testCase).ExpectedResult);    
                    break;
                default:
                    throw new IncorrectDataException($"{testCase.Template} type is incorrect");
            }
        }

        public void ClickAcceptButton()
        {
            ClickButton(AcceptButtonLocation);
            Logging.LogButtonClick("Add test case");
        }
    }
}
