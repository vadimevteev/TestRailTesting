using System.Reflection;
using log4net;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = @"Logger\Config\log4net.config")]
namespace TestRailAutomationTest.Logger
{
    public static class LoggerSingleton
    {
        private static ILog? _logger;

        public static ILog GetLogger()
        {
            return _logger ??= LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);
        }
    }
}
