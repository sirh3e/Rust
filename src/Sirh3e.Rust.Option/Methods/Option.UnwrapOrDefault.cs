using System;

namespace Sirh3e.Rust.Option
{
    public readonly partial struct Option<TSome>
    {
        public TSome UnwrapOrDefault()
        {
            return Match(
                some => some,
                Activator.CreateInstance<TSome>
            );
        }
    }
}