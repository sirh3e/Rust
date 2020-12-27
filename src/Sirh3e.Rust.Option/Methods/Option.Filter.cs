using System;

namespace Sirh3e.Rust.Option
{
    public readonly partial struct Option<TSome>
    {
        public Option<TSome> Filter(Func<TSome, bool> predicate)
        {
            if (!IsSome)
            {
                return None;
            }

            if (predicate is null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            return predicate(_some) ? Some(_some) : None;
        }
    }
}