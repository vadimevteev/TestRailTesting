using System.Linq;
using TestRailAutomationTest.Model.TestCase;
using TestRailAutomationTest.Utils;

namespace TestRailAutomationTest.Service;

public static class TestCaseCreator
{
    public static DefaultTestCase CreateRandomRequiredFields()
    {
        var testCase = new DefaultTestCase();
        FillCommonFields(testCase, RandomData.GetValueFromList(TestCaseData.Template), true);
        return testCase;
    }

    public static ExploratoryTestCase CreateRandomExploratoryTemplate()
    {
        var testCase = new ExploratoryTestCase();
        FillCommonFields(testCase, TestCaseData.ExploratoryTemplate, false);
        FillExploratoryTypeDescription(testCase);
        return testCase;
    }
    
    public static StepsTestCase CreateRandomStepsTemplate()
    {
        var testCase = new StepsTestCase();
        FillCommonFields(testCase, TestCaseData.StepsTemplate, false);
        FillStepsTypeDescription(testCase);
        return testCase;
    }
    
    public static TextTestCase CreateRandomTextType()
    {
        var testCase = new TextTestCase();
        FillCommonFields(testCase, TestCaseData.TextTemplate, false);
        FillTextTypeDescription(testCase);
        return testCase;
    }

    private static void FillCommonFields(BaseTestCase testCase, string template, bool isOptionalFieldsEmpty)
    {
        testCase.Title = RandomData.GetCompanyName();
        testCase.Section = RandomData.GetValueFromList(TestCaseData.Section);
        testCase.Template = template;
        testCase.Type = RandomData.GetValueFromList(TestCaseData.Type);
        testCase.Priority = RandomData.GetValueFromList(TestCaseData.Priority);
        testCase.Estimate = isOptionalFieldsEmpty ? default : RandomData.GetRandomByte();
        testCase.References = isOptionalFieldsEmpty ? string.Empty : RandomData.GetWord();
        testCase.AutomationType = isOptionalFieldsEmpty ? TestCaseData.AutomationType.FirstOrDefault()! : RandomData.GetValueFromList(TestCaseData.AutomationType);
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
        testCase.ExpectedResult  = RandomData.GetText();
    }

    private static void FillStepsTypeDescription(StepsTestCase testCase)
    {
        testCase.Preconditions = RandomData.GetText();
        testCase.StepDescription = RandomData.GetText();
        testCase.StepExpectedResult = RandomData.GetText();
    }
}
