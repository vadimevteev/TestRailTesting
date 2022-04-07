namespace TestRailAutomationTest.WebElement.Service;

public static class WrapperHelper
{
    public static string BuildIdXpath(string idValue) => $"//*[@id=\"{idValue}\"]";
    public static string BuildDropDownXPath(string label) => BuildIdXpath($"{label}_chzn");
    public static string BuildTextAreaXpath(string label) => BuildIdXpath($"custom_{label}_display");
}
