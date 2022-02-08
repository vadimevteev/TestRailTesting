using Bogus;

namespace TestRailAutomationTest.Utils
{
    public static class RandomData
    {
        private static readonly Faker _faker = new Faker();

        public static string GetRandomEmail()
        {
            return _faker.Person.Email;
        }

        public static string GetRandomName()
        {
            return _faker.Person.FullName;
        }

        public static string GetRandomPassword()
        {
            return _faker.Internet.Password();
        }
    }
}