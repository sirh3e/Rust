namespace Sirh3e.Rust.Result
{
    public readonly partial struct Result<TOk, TErr>
    {
        /// <summary>
        /// Returns the contained Ok value, consuming the self value.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public TOk Expect(string message)
            => Unwrap(message);
    }
}