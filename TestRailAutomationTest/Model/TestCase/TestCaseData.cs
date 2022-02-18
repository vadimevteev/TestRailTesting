using System.Collections.Generic;

namespace TestRailAutomationTest.Model.TestCase;

public static class TestCaseData
{
    public static readonly Dictionary<int, string> Section = new()
    {
        {0, "Test Cases"}
    };
    
    public static readonly Dictionary<int, string> Template = new Dictionary<int, string>()
    {
        {0, "Exploratory Session"},
        {1, "Test Case (Steps)"},
        {2, "Test Case (Text)"}
    };
    
    public static readonly Dictionary<int, string> Type = new Dictionary<int, string>()
    {
        {0, "Acceptance"},
        {1, "Accessibility"},
        {2, "Automated"},
        {3, "Compatibility"},
        {4, "Destructive"},
        {5, "Functional"},
        {6, "Other"},
        {7, "Performance"},
        {8, "Regression"},
        {9, "Security"},
        {10, "Smoke & Sanity"},
        {11, "Usability"}
    };
    
    public static readonly Dictionary<int, string> Priority = new Dictionary<int, string>()
    {
        {0, "Critical"},
        {1, "High"},
        {2, "Medium"},
        {3, "Low"}
    };
    
    public static readonly Dictionary<int, string> AutomationType = new Dictionary<int, string>()
    {
        {0, " None"},
        {1, " Ranorex"}
    };
}
