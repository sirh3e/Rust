using System;

namespace Sirh3e.Rust.Option
{
    public readonly partial struct Option<TSome>
    {
        public Option<TSome> AndThen(Func<TSome, Option<TSome>> func)
            => Match(func, () => None);
    }
}