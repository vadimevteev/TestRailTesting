namespace TestRailAutomationTest.WebElement.Service
{
    public static class SearchStrategy
    {
        public static string Id(string idValue) => $"//*[@id=\"{idValue}\"]";
        public static string DropDownXPath(string label) => Id($"{label}_chzn");
        public static string TextareaXpath(string label) => Id($"custom_{label}_display");
    }
}
