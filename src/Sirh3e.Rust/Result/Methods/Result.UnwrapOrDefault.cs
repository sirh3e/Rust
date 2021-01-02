using System;

namespace Sirh3e.Rust.Result
{
    public readonly partial struct Result<TOk, TErr>
    {
        /// <summary>
        /// Returns the contained Ok value or a default
        /// Consumes the self argument then, if Ok, returns the contained value, otherwise if Err, returns the default value for that type.
        /// </summary>
        /// <returns></returns>
        public TOk UnwrapOrDefault()
            => IsOk ?
                _ok :
                Activator.CreateInstance<TOk>();
    }
}