using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using TestRailAutomationTest.Model;

namespace TestRailAutomationTest.Service;

public static class DataReader
{
    private const string SettingsPath = @"resources\appsettings.json";
    
    public static Config GetConfig()
    {
        var stream = new StreamReader(SettingsPath);
        var json = stream.ReadToEnd();
        var config = JsonConvert.DeserializeObject<Config>(json);
        return config;
    }
}
