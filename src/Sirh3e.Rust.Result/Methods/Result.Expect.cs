namespace Sirh3e.Rust.Result
{
    public readonly partial struct Result<TOk, TErr>
    {
        public TOk Expect(string message) => Unwrap(message);
    }
}