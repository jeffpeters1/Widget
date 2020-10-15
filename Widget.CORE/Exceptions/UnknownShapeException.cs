using System;

namespace Widget.CORE.Exceptions
{
    public class UnknownShapeException : Exception
    {
        public UnknownShapeException() : base("Unknown shape specified")
        {
        }
    }
}
