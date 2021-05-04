namespace Sirh3e.Rust.Result
{
    public readonly partial struct Result<TOk, TErr>
    {
        /// <summary>
        /// Returns the contained Err value, consuming the self value.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public TErr ExpectErr(string message)
            => UnwrapErr(message);
    }
}