using System;

namespace Sirh3e.Rust.Option
{
    public partial struct Option<TSome>
    {
        /// <summary>
        /// Inserts some into the option if it is None, then returns a mutable reference to the contained value.
        /// </summary>
        /// <param name="some"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public TSome GetOrInsert(TSome some)
            => IsSome ? _some : Insert(_ = some ?? throw new ArgumentNullException());
    }
}