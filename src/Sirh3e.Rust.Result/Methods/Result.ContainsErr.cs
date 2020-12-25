namespace Sirh3e.Rust.Result
{
    public readonly partial struct Result<TOk, TErr>
    {
        public bool ContainsErr(TErr err) => IsErr && err.Equals(_err);
    }
}