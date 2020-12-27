using System;
using Sirh3e.Rust.Panic;

namespace Sirh3e.Rust.Option
{
    public readonly partial struct Option<TSome>
    {
        public TSome Unwrap()
        {
            return Unwrap($"called `Option.Unwrap()` on a `None` value of type `{typeof(TSome)}`");
        }

        public TSome Unwrap(string error)
        {
            if (string.IsNullOrEmpty(error))
                throw new ArgumentNullException(nameof(error));

            return Unwrap(() => error);
        }

        public TSome Unwrap(Func<string> error)
        {
            return Match(
                some => some,
                () => throw new PanicException(error() ??
                                               throw new ArgumentNullException(nameof(error)))
            );
        }
    }
}