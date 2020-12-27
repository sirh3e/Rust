using System;

namespace Sirh3e.Rust.Result
{
    public readonly partial struct Result<TOk, TErr>
    {
        public TOk UnwrapOr(TOk @default)
        {
            if (IsOk)
                return _ok;
            if (@default is null)
                throw new ArgumentNullException(nameof(@default));
            return @default;
        }
    }
}