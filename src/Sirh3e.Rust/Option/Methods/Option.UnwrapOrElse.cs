using System;

namespace Sirh3e.Rust.Option
{
    public partial struct Option<TSome>
    {
        /// <summary>
        /// Returns the contained Some value or computes it from a Func.
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public TSome UnwrapOrElse(Func<TSome> func)
            => Match(some => some, func ?? throw new ArgumentNullException(nameof(func)));
    }
}