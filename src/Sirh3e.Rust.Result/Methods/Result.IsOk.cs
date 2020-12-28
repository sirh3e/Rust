namespace Sirh3e.Rust.Result
{
    public readonly partial struct Result<TOk, TErr>
    {
        /// <summary>
        /// Returns true if the result is Ok.
        /// </summary>
        public readonly bool IsOk;
    }
}