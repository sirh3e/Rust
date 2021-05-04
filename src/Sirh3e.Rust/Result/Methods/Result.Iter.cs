using System;
using System.Collections.Generic;

namespace Sirh3e.Rust.Result
{
    public readonly partial struct Result<TOk, TErr>
    {
        /// <summary>
        /// Returns an iterator over the possibly contained value.
        /// The iterator yields one value if the result is Result.Ok, otherwise none.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerator<TOk> Iter()
            => GetEnumerator();
    }
}