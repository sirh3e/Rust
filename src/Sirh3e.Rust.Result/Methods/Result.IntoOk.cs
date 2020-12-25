namespace Sirh3e.Rust.Result
{
    public readonly partial struct Result<TOk, TErr>
    {
        public TOk IntoOk()
        {
            return _ok;
        }
    }
}