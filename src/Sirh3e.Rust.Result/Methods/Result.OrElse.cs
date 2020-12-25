using System;

namespace Sirh3e.Rust.Result
{
    public readonly partial struct Result<TOk, TErr>
    {
        public Result<TOk, TErr> OrElse(Func<TErr, Result<TOk, TErr>> other)
        {
            if (IsOk)
                return this;
            if (other is null)
                throw new ArgumentNullException(nameof(other));
            return other(_err);
        }
    }
}