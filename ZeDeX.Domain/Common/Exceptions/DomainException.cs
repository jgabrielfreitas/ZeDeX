using System;
using System.Collections.Generic;

namespace ZeDeX.Domain.Common.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message) { }
    }
}
