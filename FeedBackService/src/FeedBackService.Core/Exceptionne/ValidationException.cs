using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FeedBackService.Core.Exceptionne
{
    public class ValidationException : DomaineException
    {
        public ValidationException()
        {
        }

        public ValidationException(string message) : base(message)
        {
        }

        public ValidationException(string message, System.Exception inner) : base(message, inner)
        {
        }

        protected ValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
