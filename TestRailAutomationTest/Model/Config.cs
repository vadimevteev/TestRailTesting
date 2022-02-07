using System.Collections.Generic;

namespace TestRailAutomationTest.Model;

public class Config
{
    public string AppUrl { get; set; }
    
    public string Browser { get; set; }
    
    public int DefaultTimeoutSeconds { get; set; }
    
    public List<User> Users { get; set; }
    
}
