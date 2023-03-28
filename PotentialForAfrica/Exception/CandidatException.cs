using System.Runtime.Serialization;

namespace PotentialForAfrica.Exception
{
    public class CandidatException : IOException
    {
        public CandidatException()
        {
        }

        public CandidatException(string? message) : base(message)
        {
        }

        public CandidatException(string? message, System.Exception? innerException) : base(message, innerException)
        {
        }

        public CandidatException(string? message, int hresult) : base(message, hresult)
        {
        }

        protected CandidatException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
