namespace Sirh3e.Rust.Result
{
    public readonly partial struct Result<TOk, TErr>
    {
        public TErr ExpectErr(string message) => UnwrapErr(message);
    }
}