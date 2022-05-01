namespace Sirh3e.Rust.Result
{
    public readonly ref struct Ok<TOk>
    {
        internal readonly TOk Value;

        public Ok(TOk ok)
        {
            Value = ok ?? throw new ArgumentNullException(nameof(ok));
        }
    }
}