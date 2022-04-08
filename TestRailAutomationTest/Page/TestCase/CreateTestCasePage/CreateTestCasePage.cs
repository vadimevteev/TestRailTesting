using System.Linq;
using OpenQA.Selenium;
using TestRailAutomationTest.Exception;
using TestRailAutomationTest.Logger;
using TestRailAutomationTest.Model.TestCase;
using TestRailAutomationTest.Page.Constants;
using TestRailAutomationTest.Page.TestCase.CreateTestCasePage.Section;
using TestRailAutomationTest.WebElement.Wrapper;

namespace TestRailAutomationTest.Page.TestCase.CreateTestCasePage
{
    public class CreateTestCasePage : BasePage
    {
        public const string PageName = "Add test case page";
        public static readonly By HeaderTitleLocation =
            By.XPath("//*[@id=\"content-header\"]//div[contains(text(),'Add Test Case')]");
        private const string AcceptButtonId = "accept";

        private Input TitleInput => new(Driver, TestCaseProperties.Title, "Title");
        private DropDown TemplateDropDown => new(Driver, TestCaseProperties.Template, "Template");
        private DropDown TypeDropDown => new(Driver, TestCaseProperties.Type, "Type");
        private DropDown SectionDropDown => new(Driver, TestCaseProperties.Section, "Section");
        private DropDown PriorityDropDown => new(Driver, TestCaseProperties.Priority, "Priority");
        private Input EstimateInput => new(Driver, TestCaseProperties.Estimate, "Estimate");
        private Input ReferencesInput => new(Driver, TestCaseProperties.References, "References");
        private DropDown AutomationTypeDropDown => new(Driver, TestCaseProperties.AutomationType, "Automation type");
        private Button AcceptAddingButton => new(Driver, AcceptButtonId, "Add Test Case");
        
        private StepsSection SectionSteps => new(Driver);
        private ExploratorySection SectionExploratory => new(Driver);
        private TextSection SectionText => new(Driver);

        public CreateTestCasePage(IWebDriver? driver) : base(driver)
        {
        }

        public void FillTestCaseForm(BaseTestCase testCase)
        {
            TitleInput.SetValueAfterClick(testCase.Title);
            TemplateDropDown.SelectValue(testCase.Template);
            ChooseType(testCase);
            SectionDropDown.SelectValue(testCase.Section);
            PriorityDropDown.SelectValue(testCase.Priority);
            FillOptionalFields(testCase);
        }

        private void ChooseType(BaseTestCase testCase)
        {
            try
            {
                TypeDropDown.SelectValue(testCase.Type);
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
            
            EstimateInput.SetValueAfterClick(testCase.Estimate.ToString());
            ReferencesInput.SetValueAfterClick(testCase.References);
            AutomationTypeDropDown.SelectValue(testCase.AutomationType ?? TestCaseData.AutomationType.FirstOrDefault()!);
            FillDescription(testCase);
        }

        private void FillDescription(BaseTestCase testCase)
        {
            switch (testCase.Template)
            {
                case TestCaseData.ExploratoryTemplate:
                    SectionExploratory.FillSteps(testCase);
                    break;

                case TestCaseData.StepsTemplate:
                    SectionSteps.FillSteps(testCase);
                    break;

                case TestCaseData.TextTemplate:
                    SectionText.FillSteps(testCase);
                    break;
                default:
                    var message = $"{testCase.Template} type is incorrect";
                    LoggerSingleton.GetLogger().Error(message);
                    throw new IncorrectDataException(message);
            }
        }

        public void ClickAcceptButton() => AcceptAddingButton.Click();
    }
}
