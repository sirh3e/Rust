using System;

namespace Sirh3e.Rust.Result
{
    public readonly partial struct Result<TOk, TErr>
    {
        public TOk UnwrapOrElse(Func<TErr, TOk> mapper)
        {
            if (IsOk)
                return _ok;
            if (mapper is null)
                throw new ArgumentNullException(nameof(mapper));
            return mapper(_err);
        }
    }
}