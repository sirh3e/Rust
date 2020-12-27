using System;

namespace Sirh3e.Rust.Option
{
    public readonly partial struct Option<TSome>
    {
        public TSome UnwrapOrElse(Func<TSome> func)
        {
            return Match(some => some, func ?? throw new ArgumentNullException(nameof(func)));
        }
    }
}