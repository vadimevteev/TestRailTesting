using System.Reflection;
using log4net;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = @"Logger\Config\log4net.config")]
namespace TestRailAutomationTest.Logger
{
    public static class Logging
    {
        public static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);

        public static void LogInputValue(string inputName, string? data)
        {
            Logger.Info($"Input \"{inputName}\" - set value \"{data}\"");
        }

        public static void LogButtonClick(string name)
        {
            Logger.Info($"Button \"{name}\" - click");
        }

        public static void LogDropDownSelect(string name, string value)
        {
            Logger.Info($"Dropdown \"{name}\" - choose value \"{value}\"");
        }
    }
}
