using System;
using Sirh3e.Rust.Panic;

namespace Sirh3e.Rust.Option
{
    public readonly partial struct Option<TSome>
    {
        internal void ExpectFailed(string message)
        {
            throw new PanicException(message ?? throw new ArgumentNullException(nameof(message)));
        }
    }
}