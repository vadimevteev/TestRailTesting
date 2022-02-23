using System.Collections.Generic;

namespace TestRailAutomationTest.Model.TestCase;

public static class TestCaseData
{
    public static readonly List<string> Section = new()
    {
        "Test Cases"
    };
    
    public static readonly List<string> Template = new()
    {
        "Exploratory Session",
        "Test Case (Steps)",
        "Test Case (Text)"
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
