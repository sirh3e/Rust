using System;

namespace Sirh3e.Rust.Result
{
    public readonly partial struct Result<TOk, TErr>
    {
        public U MapOrElse<U>(Func<TErr, U> @default, Func<TOk, U> func)
        {
            if (IsOk)
            {
                if (func is null)
                    throw new ArgumentNullException(nameof(func));
                return func(_ok);
            }

            if (@default is null)
                throw new ArgumentNullException(nameof(@default));

            return @default(_err);
        }
    }
}