using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;


namespace FeedBackService.Core.Exceptionne
{
    public class NotFoundException : DomaineException
    {
        public NotFoundException()
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string message, System.Exception inner) : base(message, inner)
        {
        }

        protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
