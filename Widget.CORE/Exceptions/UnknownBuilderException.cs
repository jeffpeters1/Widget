using System;

namespace Widget.CORE.Exceptions
{
    [Serializable]
    public class UnknownBuilderException : Exception
    {
        public UnknownBuilderException() : base("Unknown builder or application used")
        {
        }
    }
}
