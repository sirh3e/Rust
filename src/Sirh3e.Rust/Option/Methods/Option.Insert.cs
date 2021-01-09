using System;

namespace Sirh3e.Rust.Option
{
    public readonly partial struct Option<TSome>
    {
        /// <summary>
        /// Inserts value into the option.
        /// If the option already contains a value, the old value is dropped.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public TSome Insert(TSome value)
        {
            throw new NotImplementedException();

            if (value is null)
                throw new ArgumentNullException(nameof(value));
        }
    }
}