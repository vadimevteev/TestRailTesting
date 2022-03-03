using System.Runtime.Serialization;

namespace TestRailAutomationTest.Exception
{

    public class PageNotOpenedException : System.Exception
    {
        public PageNotOpenedException()
        {
        }

        protected PageNotOpenedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public PageNotOpenedException(string? message) : base(message)
        {
        }

        public PageNotOpenedException(string? message, System.Exception? innerException) : base(message, innerException)
        {
        }
    }
}
