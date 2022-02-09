using TestRailAutomationTest.Model;
using TestRailAutomationTest.Utils;

namespace TestRailAutomationTest.Service
{
    public static class UserCreator
    {
        public static User CreateRandom()
        {
            return new User()
            {
                Email = RandomData.GetEmail(),
                Name = RandomData.GetName(),
                Password = RandomData.GetPassword()
            };
        }
    }
}
