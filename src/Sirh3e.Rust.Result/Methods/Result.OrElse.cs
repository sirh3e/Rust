using System;

namespace Sirh3e.Rust.Result
{
    public readonly partial struct Result<TOk, TErr>
    {
        /// <summary>
        /// Calls other if the result is Err, otherwise returns the Ok value of self.
        /// This function can be used for control flow based on result values.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Throws only if other is null</exception>
        public Result<TOk, TErr> OrElse(Func<TErr, Result<TOk, TErr>> other)
        {
            return Match(Ok, err =>
            {
                if (other is null)
                    throw new ArgumentNullException(nameof(other));
                return other(err);
            });
        }
    }
}