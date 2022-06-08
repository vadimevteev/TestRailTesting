using System.Runtime.Serialization;

namespace TestRailAutomationTest.Exception;

public class HttpStatusCodeException : System.Exception
{
    public HttpStatusCodeException()
    {
    }

    protected HttpStatusCodeException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public HttpStatusCodeException(string? message) : base(message)
    {
    }

    public HttpStatusCodeException(string? message, System.Exception? innerException) : base(message, innerException)
    {
    }
}
