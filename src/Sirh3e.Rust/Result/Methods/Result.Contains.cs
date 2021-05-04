namespace Sirh3e.Rust.Result
{
    public readonly partial struct Result<TOk, TErr>
    {
        /// <summary>
        /// Returns true if the result is an Ok value containing the given value.
        /// </summary>
        /// <param name="ok"></param>
        /// <returns>Returns true if the result is an Ok value containing the given value.</returns>
        public bool Contains(TOk ok)
            => ok != null && IsOk && ok.Equals(_ok);
    }
}