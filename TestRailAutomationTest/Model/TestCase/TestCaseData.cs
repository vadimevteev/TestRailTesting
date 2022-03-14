using System.Collections.Generic;

namespace TestRailAutomationTest.Model.TestCase
{
    public static class TestCaseData
    {
        public const string ExploratoryTemplate = "Exploratory Session";
        public const string StepsTemplate = "Test Case (Steps)";
        public const string TextTemplate = "Test Case (Text)";

        public const string Section = "Test Cases";

        public static readonly List<string> Template = new()
        {
            ExploratoryTemplate,
            StepsTemplate,
            TextTemplate
        };

        public static readonly List<string> Type = new()
        {
            "Acceptance",
            "Accessibility",
            "Automated",
            "Compatibility",
            "Destructive",
            "Functional",
            "Other",
            "Performance",
            "Regression",
            "Security",
            "Smoke & Sanity",
            "Usability"
        };

        public static readonly List<string> Priority = new()
        {
            "Critical",
            "High",
            "Medium",
            "Low"
        };

        public static readonly List<string> AutomationType = new()
        {
            " None",
            " Ranorex"
        };
    }
}
