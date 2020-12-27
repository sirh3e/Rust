using System;

namespace Sirh3e.Rust.Option
{
    public readonly partial struct Option<TSome>
    {
        public Option<TSome> OrElse(Func<Option<TSome>> func)
        {
            return Match(Some, func ?? throw new ArgumentNullException(nameof(func)));
        }
    }
}