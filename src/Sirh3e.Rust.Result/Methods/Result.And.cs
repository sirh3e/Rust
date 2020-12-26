namespace Sirh3e.Rust.Result
{
    public readonly partial struct Result<TOk, TErr>
    {
        /// <summary>
        /// Returns res if the result is Ok, otherwise returns the Err value of self
        /// </summary>
        /// <param name="res"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns>Returns res if the result is Ok, otherwise returns the Err value of self</returns>
        public Result<T, TErr> And<T>(Result<T, TErr> res)
        {
            if (IsOk && res.IsErr)
            {
                return Result<T, TErr>.Err(res._err);
            }

            return IsErr switch
            {
                true when res.IsOk => Result<T, TErr>.Err(_err),
                true when res.IsErr => Result<T, TErr>.Err(_err),
                _ => res
            };
        }
    }
}