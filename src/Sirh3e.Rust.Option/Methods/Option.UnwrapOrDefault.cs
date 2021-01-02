using System;

namespace Sirh3e.Rust.Option
{
    public readonly partial struct Option<TSome>
    {
        /// <summary>
        /// Returns the contained Some value or a default
        /// Consumes the self argument then, if Some, returns the contained value, otherwise if None, returns the default value for that type.
        /// </summary>
        /// <returns></returns>
        public TSome UnwrapOrDefault()
        {
            return Match(
                some => some,
                Activator.CreateInstance<TSome>
            );
        }
    }
}