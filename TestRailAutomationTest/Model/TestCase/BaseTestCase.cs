namespace TestRailAutomationTest.Model.TestCase
{
    public abstract class BaseTestCase
    {
        public string Title { get; set; }

        public string Section { get; set; }

        public string Template { get; set; }

        public string Type { get; set; }

        public string Priority { get; set; }

        public int? Estimate { get; set; }

        public string? References { get; set; }

        public string? AutomationType { get; set; }
    }
}
