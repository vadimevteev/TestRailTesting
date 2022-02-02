using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using TestRailAutomationTest.Model;

namespace TestRailAutomationTest.Service;

public static class DataReader
{
    private static readonly string SettingsPath = @"resources\appsettings.json";
    public static Config GetConfig()
    {
        StreamReader stream = new StreamReader(SettingsPath);
        string json = stream.ReadToEnd();
        Config config = JsonConvert.DeserializeObject<Config>(json);
        return config;
    }
}
