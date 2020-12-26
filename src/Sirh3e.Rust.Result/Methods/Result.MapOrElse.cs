using System;

namespace Sirh3e.Rust.Result
{
    public readonly partial struct Result<TOk, TErr>
    {
        /// <summary>
        /// Maps a Result&lt;TOk, TErr&gt; to T by applying a function to a contained Ok value, or a fallback function to a contained Err value.
        /// This function can be used to unpack a successful result while handling an error.
        /// </summary>
        /// <param name="default"></param>
        /// <param name="map"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public T MapOrElse<T>(Func<TErr, T> @default, Func<TOk, T> map)
        {
            if (IsOk)
            {
                if (map is null)
                {
                    throw new ArgumentNullException(nameof(map));
                }

                return map(_ok);
            }

            if (@default is null)
            {
                throw new ArgumentNullException(nameof(@default));
            }

            return @default(_err);
        }
    }
}