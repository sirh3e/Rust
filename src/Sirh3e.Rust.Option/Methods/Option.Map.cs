using System;

namespace Sirh3e.Rust.Option
{
    public readonly partial struct Option<TSome>
    {
        public Option<T> Map<T>(Func<TSome, T> map)
        {
            return Match(
                some => Option<T>.Some(map(some) ?? throw new ArgumentNullException(nameof(map))),
                () => Option<T>.None
            );
        }
    }
}