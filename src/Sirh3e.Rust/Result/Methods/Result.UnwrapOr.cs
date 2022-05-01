namespace Sirh3e.Rust.Result
{
    public readonly partial struct Result<TOk, TErr>
    {
        /// <summary>
        /// Returns the contained Ok value or a provided default.
        /// Arguments passed to unwrap_or are eagerly evaluated; if you are passing the result of a function call, it is recommended to use unwrap_or_else, which is lazily evaluated.
        /// </summary>
        /// <param name="default"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public TOk UnwrapOr(TOk @default)
        {
            if ( IsOk )
            {
                return _ok;
            }

            return @default ?? throw new ArgumentNullException(nameof(@default));
        }
    }
}