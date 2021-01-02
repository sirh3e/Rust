using System;

namespace Sirh3e.Rust.Option
{
    public readonly partial struct Option<TSome>
    {
        /// <summary>
        /// Returns the option if it contains a value, otherwise calls func and returns the result. 
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public Option<TSome> OrElse(Func<Option<TSome>> func)
        {
            return Match(Some, func ?? throw new ArgumentNullException(nameof(func)));
        }
    }
}