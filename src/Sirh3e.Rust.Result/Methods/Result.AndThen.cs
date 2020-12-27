using System;

namespace Sirh3e.Rust.Result
{
    public readonly partial struct Result<TOk, TErr>
    {
        public Result<U, TErr> AndThen<U>(Func<TOk, Result<U, TErr>> op)
        {
            if (!IsOk)
                return Result<U, TErr>.Err(_err);

            if (op is null)
                throw new ArgumentNullException(nameof(op));
            return op(_ok);
        }
    }
}