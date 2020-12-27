using System;

namespace Sirh3e.Rust.Result
{
    public readonly partial struct Result<TOk, TErr>
    {
        public Result<U, TErr> Map<U>(Func<TOk, U> mapper)
        {
            if (!IsOk)
                return Result<U, TErr>.Err(_err);

            if (mapper is null)
                throw new ArgumentNullException(nameof(mapper));

            return new Result<U, TErr>(mapper(_ok));
        }
    }
}