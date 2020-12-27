using System;

namespace Sirh3e.Rust.Option
{
    public readonly partial struct Option<TSome>
    {
        public T MapOr<T>(T @default, Func<TSome, T> convert)
        {
            return Match(
                some => convert(some) ?? throw new ArgumentNullException(nameof(convert)),
                () => @default ?? throw new ArgumentNullException(nameof(@default))
            );
        }
    }
}