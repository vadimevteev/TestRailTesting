using System.Runtime.Serialization;

namespace TestRailAutomationTest.Exception;

public class ClientRequestException : System.Exception
{
    public ClientRequestException()
    {
    }

    protected ClientRequestException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public ClientRequestException(string? message) : base(message)
    {
    }

    public ClientRequestException(string? message, System.Exception? innerException) : base(message, innerException)
    {
    }
}
