namespace Sirh3e.Rust.Result
{
    public readonly partial struct Result<TOk, TErr>
    {
        public Result<TOk, TErr> Or(Result<TOk, TErr> other) => IsOk ? this : other;
    }
}