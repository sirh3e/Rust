using System;

namespace Sirh3e.Rust.Option
{
    public readonly partial struct Option<TSome>
    {
        public TSome UnwrapOr(TSome @default)
        {
            return Match(
                some => some,
                () => @default ?? throw new ArgumentNullException(nameof(@default))
            );
        }
    }
}