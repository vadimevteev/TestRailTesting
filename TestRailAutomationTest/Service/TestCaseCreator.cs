using TestRailAutomationTest.Model.TestCase;
using TestRailAutomationTest.Utils;

namespace TestRailAutomationTest.Service
{
    public static class TestCaseCreator
    {
        public static DefaultTestCase CreateRandomRequiredFields()
        {
            var testCase = new DefaultTestCase();
            FillRequiredFields(testCase, RandomData.GetValueFromList(TestCaseData.Template));
            return testCase;
        }

        public static ExploratoryTestCase CreateRandomExploratoryTemplate()
        {
            var testCase = new ExploratoryTestCase();
            FillCommonFields(testCase, TestCaseData.ExploratoryTemplate);
            FillExploratoryTypeDescription(testCase);
            return testCase;
        }

        public static StepsTestCase CreateRandomStepsTemplate()
        {
            var testCase = new StepsTestCase();
            FillCommonFields(testCase, TestCaseData.StepsTemplate);
            FillStepsTypeDescription(testCase);
            return testCase;
        }

        public static TextTestCase CreateRandomTextType()
        {
            var testCase = new TextTestCase();
            FillCommonFields(testCase, TestCaseData.TextTemplate);
            FillTextTypeDescription(testCase);
            return testCase;
        }

        private static void FillCommonFields(BaseTestCase testCase, string template)
        {
            FillRequiredFields(testCase, template);
            FillOptionalFields(testCase);
        }

        private static void FillRequiredFields(BaseTestCase testCase, string template)
        {
            testCase.Title = RandomData.GetCompanyName();
            testCase.Section = TestCaseData.Section;
            testCase.Template = template;
            testCase.Type = RandomData.GetValueFromList(TestCaseData.Type);
            testCase.Priority = RandomData.GetValueFromList(TestCaseData.Priority);
        }

        private static void FillOptionalFields(BaseTestCase testCase)
        {
            testCase.Estimate = RandomData.GetRandomByte();
            testCase.References = RandomData.GetWord();
            testCase.AutomationType = RandomData.GetValueFromList(TestCaseData.AutomationType);
        }

        private static void FillExploratoryTypeDescription(ExploratoryTestCase testCase)
        {
            testCase.Mission = RandomData.GetText();
            testCase.Goals = RandomData.GetText();
        }

        private static void FillTextTypeDescription(TextTestCase testCase)
        {
            testCase.Preconditions = RandomData.GetText();
            testCase.Steps = RandomData.GetText();
            testCase.ExpectedResult = RandomData.GetText();
        }

        private static void FillStepsTypeDescription(StepsTestCase testCase)
        {
            testCase.Preconditions = RandomData.GetText();
            testCase.StepDescription = RandomData.GetText();
            testCase.StepExpectedResult = RandomData.GetText();
        }
    }
}
