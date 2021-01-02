using System;

namespace Sirh3e.Rust.Option
{
    public readonly partial struct Option<TSome>
    {
        /// <summary>
        /// Inserts a value computed from func into the option if it is None, then returns a mutable reference to the contained value.
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Option<TSome> GetOrInsertWith(Func<TSome> func)
        {
            throw new NotImplementedException();
        }
    }
}