using TestRailAutomationTest.Model;

namespace TestRailAutomationTest.Service;

public static class UserCreator
{
    private static readonly string UserEmail = DataReader.GetConfig().Email;
    private static readonly string UserPassword = DataReader.GetConfig().Password;

    public static User CreateUser()
    {
        return new User(UserEmail, UserPassword);
    }
}
