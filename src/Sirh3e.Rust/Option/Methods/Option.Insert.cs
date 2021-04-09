using System;

namespace Sirh3e.Rust.Option
{
    public partial struct Option<TSome>
    {
        /// <summary>
        /// Inserts value into the option then returns a mutable reference to it.
        /// If the option already contains a value, the old value is dropped / disposed.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Returns the inserted value back</returns>
        /// <exception cref="ArgumentNullException">If the inserted value is null</exception>
        public TSome Insert(TSome value)
        {
            _ = value ?? throw new ArgumentNullException(nameof(value));

            if (IsSome && _some is IDisposable some)
            {
                some.Dispose();
            }

            _some = value;
            IsSome = true;

            return _some;
        }
    }
}