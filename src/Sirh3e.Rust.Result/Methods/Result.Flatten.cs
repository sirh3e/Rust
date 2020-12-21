using System;

namespace Sirh3e.Rust.Result
{
    public readonly partial struct Result<TOk, TErr>
    {
        public Result<TOk, TErr> Flatten()
        {
            if (this is not Result<Result<TOk, TErr>, TErr> result)
                throw new NotImplementedException();

            return result.IsOk ? result._ok : Err(result._err);
        }
    }
}