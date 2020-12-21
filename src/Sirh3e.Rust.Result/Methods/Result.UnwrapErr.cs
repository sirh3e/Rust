using System;

namespace Sirh3e.Rust.Result
{
    public readonly partial struct Result<TOk, TErr>
    {
        public TErr UnwrapErr()
        {
            if (IsErr)
                return _err;

            return UnwrapErr(ok =>
            {
                return ok switch
                {
                    _ => $""
                };
            });
        }

        public TErr UnwrapErr(string message)
        {
            if (IsErr)
                return _err;

            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException(nameof(message));
            throw new NotImplementedException(message); //ToDo create panic
        }

        public TErr UnwrapErr(Func<TOk, string> ok)
        {
            if (ok is null)
                throw new ArgumentNullException(nameof(ok));
            return UnwrapErr(ok(_ok));
        }
    }
}