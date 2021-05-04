namespace Sirh3e.Rust.Result
{
    public readonly partial struct Result<TOk, TErr>
    {
        //ToDo missing documentation
        public Result<TOk, TErr> Cloned()
            => Clone();
    }
}