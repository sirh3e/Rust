using System;
using Sirh3e.Rust.Panic;

namespace Sirh3e.Rust.Option
{
    public readonly partial struct Option<TSome>
    {
        private static void ExpectNoneFailed<T>(string message, T some)
            => throw new PanicException($"{message ?? throw new ArgumentNullException(nameof(message))}: {some ?? throw new ArgumentNullException(nameof(some))}");
    }
}