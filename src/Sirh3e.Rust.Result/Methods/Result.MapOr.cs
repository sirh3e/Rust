using System;

namespace Sirh3e.Rust.Result
{
    public readonly partial struct Result<TOk, TErr>
    {
        public U MapOr<U>(U @default, Func<TOk, U> mapper)
        {
            if (!IsErr)
                return mapper(_ok);

            if (@default is null)
                throw new ArgumentNullException(nameof(@default));
            return @default;
        }
    }
}