using System.Runtime.Serialization;

namespace PotentialForAfrica.Exception
{
    public class EmailSenderException : IOException
    {
        public EmailSenderException()
        {
        }

        public EmailSenderException(string? message) : base(message)
        {
        }

        public EmailSenderException(string? message, System.Exception? innerException) : base(message, innerException)
        {
        }

        public EmailSenderException(string? message, int hresult) : base(message, hresult)
        {
        }

        protected EmailSenderException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
