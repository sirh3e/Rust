using System;

namespace Sirh3e.Rust.Result
{
    public readonly partial struct Result<TOk, TErr>
    {
        public Result<TOk, F> MapErr<F>(Func<TErr, F> op)
        {
            if (IsOk)
            {
                return Result<TOk, F>.Ok(_ok);
            }

            if (op is null)
                throw new ArgumentNullException(nameof(op));

            return Result<TOk, F>.Err(op(_err));
        }
    }
}