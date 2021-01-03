using System;

namespace Sirh3e.Rust.Option
{
    public readonly partial struct Option<TSome>
    {
        /// <summary>
        /// Inserts some into the option if it is None, then returns a mutable reference to the contained value.
        /// </summary>
        /// <param name="some"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public TSome GetOrInsert(TSome some)
        {
            throw new NotImplementedException();
        }
    }
}