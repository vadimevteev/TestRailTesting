using log4net;
using TestRailAutomationTest.Logger;

namespace TestRailAutomationTest.Utils
{
    public static class LoggerHelper
    {
        private static readonly ILog? Logger = LoggerSingleton.GetLogger();
        
        public static void LogInputValue(string inputName, string? data)
        {
            Logger?.Info($"Input \"{inputName}\" - set value \"{data}\"");
        }

        public static void LogButtonClick(string name)
        {
            Logger?.Info($"Button \"{name}\" - click");
        }

        public static void LogDropDownSelect(string name, string value)
        {
            Logger?.Info($"Dropdown \"{name}\" - choose value \"{value}\"");
        }

        public static void LogButtonLinkClick(string name)
        {
            Logger?.Info($"Link \"{name}\" - open");
        }
        
        public static void LogCheckboxClick(string name)
        {
            Logger?.Info($"Checkbox \"{name}\" - select");
        }
        
        public static void LogRadioClick(string name)
        {
            Logger?.Info($"Link \"{name}\" - open");
        }
    }
}