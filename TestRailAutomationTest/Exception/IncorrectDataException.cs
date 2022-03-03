using System.Runtime.Serialization;

namespace TestRailAutomationTest.Exception
{

    public class IncorrectDataException : System.Exception
    {
        public IncorrectDataException()
        {
        }

        protected IncorrectDataException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public IncorrectDataException(string? message) : base(message)
        {
        }

        public IncorrectDataException(string? message, System.Exception? innerException) : base(message, innerException)
        {
        }
    }
}
