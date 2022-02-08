using TestRailAutomationTest.Model;
using TestRailAutomationTest.Utils;

namespace TestRailAutomationTest.Service
{
    public static class UserCreator
    {
        public static User CreateRandomUser()
        {
            return new User()
            {
                Email = RandomData.GetRandomEmail(),
                Name = RandomData.GetRandomName(),
                Password = RandomData.GetRandomPassword()
            };
        }
    }
}