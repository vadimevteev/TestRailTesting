using TestRailAutomationTest.Exception;
using TestRailAutomationTest.Model.TestCase;
using TestRailAutomationTest.Utils;

namespace TestRailAutomationTest.Service;

public static class TestCaseCreator
{
    public static BaseTestCase CreateRandomAllFields()
    {
        return CreateTestCase(RandomData.GetText());
    }

    public static BaseTestCase CreateRandomRequiredFields()
    {
        return CreateTestCase("");
    }

    private static BaseTestCase CreateTestCase(string optionalTextFieldsValue)
    {
        var testCase = CreateRequiredFields();
        FillOptionalFields(testCase,optionalTextFieldsValue);
        return testCase;
    }

    private static BaseTestCase CreateRequiredFields()
    {
        return new BaseTestCase
        {
            Title = RandomData.GetCompanyName(),
            Section = RandomData.GetValueFromList(TestCaseData.Section),
            Template = RandomData.GetValueFromList(TestCaseData.Template),
            Type = RandomData.GetValueFromList(TestCaseData.Type),
            Priority = RandomData.GetValueFromList(TestCaseData.Priority)
        };
    }

    private static void FillOptionalFields(BaseTestCase baseTestCase, string optionalTextFieldsValue)
    {
        if (optionalTextFieldsValue == "")
        {
            baseTestCase.Estimate = 0;
            baseTestCase.References = optionalTextFieldsValue;
            baseTestCase.AutomationType = " None";
        }
        else
        {
            baseTestCase.Estimate = RandomData.GetRandomByte();
            baseTestCase.References = RandomData.GetWord();
            baseTestCase.AutomationType = RandomData.GetValueFromList(TestCaseData.AutomationType);
        }
        FillTestCaseDescription(baseTestCase, optionalTextFieldsValue);
    }
    
    private static void FillTestCaseDescription(BaseTestCase baseTestCase, string optionalTextFieldsValue)
    {
        switch (baseTestCase.Template)
        {
            case "Exploratory Session":
                baseTestCase.Mission = optionalTextFieldsValue;
                baseTestCase.Goals = optionalTextFieldsValue;
                break;
            case "Test Case (Steps)":
                baseTestCase.Preconditions = optionalTextFieldsValue;
                baseTestCase.StepDescription = optionalTextFieldsValue;
                baseTestCase.StepExpectedResult = optionalTextFieldsValue;
                break;
            case "Test Case (Text)":
                baseTestCase.Preconditions = optionalTextFieldsValue;
                baseTestCase.Steps = optionalTextFieldsValue;
                baseTestCase.ExpectedResult = optionalTextFieldsValue;
                break;
            default:
                throw new IncorrectDataException($"{baseTestCase.Section} section type is incorrect");
        }
    }
}
