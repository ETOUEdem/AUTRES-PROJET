using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FeedBackService.Core.Exceptionne
{
    public class DomaineException : Exception
    {
        public DomaineException()
        {
        }

        public DomaineException(string message) : base(message)
        {
        }

        public DomaineException(string message, Exception inner)
               : base(message, inner)
        {
        }

        protected DomaineException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
