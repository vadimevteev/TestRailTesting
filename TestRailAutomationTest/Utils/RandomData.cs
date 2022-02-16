using Bogus;

namespace TestRailAutomationTest.Utils
{
    public static class RandomData
    {
        public static readonly Faker Faker = new();

        public static string GetEmail()
        {
            return Faker.Person.Email;
        }

        public static string GetName()
        {
            return Faker.Person.FullName;
        }

        public static string GetPassword()
        {
            return Faker.Internet.Password();
        }

        public static string GetCompanyName()
        {
            return Faker.Company.CompanyName();
        }

        public static string GetText()
        {
            return Faker.Lorem.Paragraph();
        }

        public static bool GetBool()
        {
            return Faker.Random.Bool();
        }
    }
}
