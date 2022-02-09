using Bogus;

namespace TestRailAutomationTest.Utils
{
    public static class RandomData
    {
        private static readonly Faker _faker = new Faker();

        public static string GetEmail()
        {
            return _faker.Person.Email;
        }

        public static string GetName()
        {
            return _faker.Person.FullName;
        }

        public static string GetPassword()
        {
            return _faker.Internet.Password();
        }

        public static string GetCompanyName()
        {
            return _faker.Company.CompanyName();
        }

        public static string GetRandomText()
        {
            return _faker.Lorem.Paragraph();
        }
    }
}
