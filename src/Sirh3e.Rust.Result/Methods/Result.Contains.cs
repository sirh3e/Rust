namespace Sirh3e.Rust.Result
{
    public readonly partial struct Result<TOk, TErr>
    {
        public bool Contains(TOk ok) => IsErr && ok.Equals(_ok);
    }
}