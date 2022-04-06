using TestRailAutomationTest.Logger;

namespace TestRailAutomationTest.Utils
{
    public static class LoggerHelper
    {
        public static void LogInputValue(string inputName, string? data)
        {
            LoggerSingleton.GetLogger().Info($"Input \"{inputName}\" - set value \"{data}\"");
        }

        public static void LogButtonClick(string name)
        {
            LoggerSingleton.GetLogger().Info($"Button \"{name}\" - click");
        }

        public static void LogDropDownSelect(string name, string value)
        {
            LoggerSingleton.GetLogger().Info($"Dropdown \"{name}\" - choose value \"{value}\"");
        }
    }
}