using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using TestRailAutomationTest.Model;

namespace TestRailAutomationTest.Service;

public static class DataReader
{
    private const string SettingsPath = @"resources\appsettings.json";
    
    public static Config GetConfig()
    {
        var config = new Config();
        var stream = new StreamReader(SettingsPath);
        var json = stream.ReadToEnd();

        try
        {
            config = JsonConvert.DeserializeObject<Config>(json);
        }
        catch (JsonException exception)
        {
            Debug.WriteLine(exception.Message);
        }

        return config;
    }
}
