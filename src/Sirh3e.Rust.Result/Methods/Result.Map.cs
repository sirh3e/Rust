using System;

namespace Sirh3e.Rust.Result
{
    public readonly partial struct Result<TOk, TErr>
    {
        /// <summary>
        /// Maps a Result&lt;TOk, TErr&gt; to Result&lt;T, TErr&gt; by applying a function to a contained Ok value, leaving an Err value untouched.
        /// This function can be used to compose the results of two functions.
        /// </summary>
        /// <param name="map"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Throws only if map is null</exception>
        public Result<T, TErr> Map<T>(Func<TOk, T> map)
        {
            if (IsErr)
            {
                return Result<T, TErr>.Err(_err);
            }

            if (map is null)
            {
                throw new ArgumentNullException(nameof(map));
            }

            return new Result<T, TErr>(map(_ok));
        }
    }
}