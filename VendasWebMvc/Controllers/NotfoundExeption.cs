using System;
using System.Runtime.Serialization;

namespace VendasWebMvc.Controllers
{
    [Serializable]
    internal class NotfoundExeption : Exception
    {
        public NotfoundExeption()
        {
        }

        public NotfoundExeption(string message) : base(message)
        {
        }

        public NotfoundExeption(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotfoundExeption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}