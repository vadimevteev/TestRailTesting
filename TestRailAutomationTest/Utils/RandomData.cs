using Bogus;
using TestRailAutomationTest.Model;

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

        public static string GetText()
        {
            return _faker.Lorem.Paragraph();
        }

        public static bool GetBool()
        {
            return _faker.Random.Bool();
        }

        public static ProjectType GetProjectType()
        {
            return _faker.Random.Enum(ProjectType.MultipleTestSuites,
                ProjectType.SingleRepositoryForAllCases,
                ProjectType.SingleRepositoryWithBaselineSupport);
        }
    }
}
