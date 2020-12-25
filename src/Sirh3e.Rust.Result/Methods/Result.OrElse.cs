using System;

namespace Sirh3e.Rust.Result
{
    public readonly partial struct Result<TOk, TErr>
    {
        public Result<TOk, TErr> OrElse(Func<TErr, TOk> other) => Ok(IsOk ? _ok : other(_err));
    }
}