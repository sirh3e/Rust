namespace Sirh3e.Rust.Result
{
    public readonly partial struct Result<TOk, TErr>
    {
        public bool Contains(TOk ok) => IsOk && ok.Equals(_ok);
    }
}