using System;

namespace Sirh3e.Rust.Panic
{
    public class PanicException : Exception
    {
        public PanicException(string message)
            : base(message)
        {
        }
    }
}