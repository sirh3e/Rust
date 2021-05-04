namespace Sirh3e.Rust.Result
{
    public static class Extension
    {
        public static Ok<TOk> Ok<TOk>(TOk ok) => new(ok);
        public static Err<TErr> Err<TErr>(TErr err) => new(err);
    }
}