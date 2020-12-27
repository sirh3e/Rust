using System;
using Sirh3e.Rust.Panic;

namespace Sirh3e.Rust.Result
{
    public readonly partial struct Result<TOk, TErr>
    {
        public TErr UnwrapErr()
        {
            return UnwrapErr(ok =>
            {
                return ok switch
                {
                    _ => $"Cannot unwrap \"Err\" when the result is \"Ok\": {ok}."
                };
            });
        }

        public TErr UnwrapErr(string message)
        {
            if (IsErr)
                return _err;

            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException(nameof(message));
            throw new PanicException(message);
        }

        public TErr UnwrapErr(Func<TOk, string> ok)
        {
            if (ok is null)
                throw new ArgumentNullException(nameof(ok));
            return UnwrapErr(ok(_ok));
        }
    }
}