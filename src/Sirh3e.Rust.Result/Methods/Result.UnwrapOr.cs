using System;

namespace Sirh3e.Rust.Result
{
    public readonly partial struct Result<TOk, TErr>
    {
        /// <summary>
        /// Returns the contained Ok value or a default
        /// Consumes the self argument then, if Ok, returns the contained value, otherwise if Err, returns the default value for that type.
        /// </summary>
        /// <param name="default"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public TOk UnwrapOr(TOk @default)
        {
            if (IsOk)
            {
                return _ok;
            }

            if (@default is null)
            {
                throw new ArgumentNullException(nameof(@default));
            }

            return @default;
        }
    }
}