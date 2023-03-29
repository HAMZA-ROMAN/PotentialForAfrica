using System.Runtime.Serialization;

namespace PotentialForAfrica.Exception
{
    public class CandidatServiceException : IOException
    {
        public CandidatServiceException()
        {
        }

        public CandidatServiceException(string? message) : base(message)
        {
        }

        public CandidatServiceException(string? message, System.Exception? innerException) : base(message, innerException)
        {
        }

        public CandidatServiceException(string? message, int hresult) : base(message, hresult)
        {
        }

        protected CandidatServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
