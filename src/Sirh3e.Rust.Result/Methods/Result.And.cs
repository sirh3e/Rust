namespace Sirh3e.Rust.Result
{
    public readonly partial struct Result<TOk, TErr>
    {
        public Result<U, TErr> And<U>(Result<U, TErr> res)
        {
            if (IsOk && res.IsErr)
            {
                return Result<U, TErr>.Err(res._err);
            }

            return IsErr switch
            {
                true when res.IsOk => Result<U, TErr>.Err(_err),
                true when res.IsErr => Result<U, TErr>.Err(_err),
                _ => res
            };
        }
    }
}