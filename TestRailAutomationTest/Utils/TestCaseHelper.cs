using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TestRailAutomationTest.Utils
{
    public static class TestCaseHelper
    {
        public static int ConvertTimeToMinutes(string time)
        {
            const string pattern = @"[0-9]+";
            var timeMeasurements = new List<int>();
            foreach (Match match in Regex.Matches(time, pattern))
            {
                timeMeasurements.Add(int.Parse(match.Value));
            }

            var result = 0;
            if (time.Contains("hour"))
            {
                result = timeMeasurements.FirstOrDefault() * 60;
            }

            if (time.Contains("minute"))
            {
                result += timeMeasurements.Last();
            }

            return result;
        }
    }
}
