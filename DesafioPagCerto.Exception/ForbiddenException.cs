using System;

namespace DesafioPagCerto.Exception
{
    public class ForbiddenException : ApplicationException
    {
        public ForbiddenException(string message) : base(message)
        {
        }
    }
}