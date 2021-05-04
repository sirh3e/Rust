namespace Sirh3e.Rust.Result
{
    public static class Extension
    {
        public static Ok<TOk> Ok<TOk>(TOk ok) => new(ok);
    }
}