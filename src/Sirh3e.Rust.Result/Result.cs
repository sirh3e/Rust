using System;

namespace Sirh3e.Rust.Result
{
    public readonly partial struct Result<TOk, TErr>
    {
        private readonly TOk _ok;
        private readonly TErr _err;


        private Result(TOk ok)
        {
            _ok = ok ?? throw new ArgumentNullException(nameof(ok));
            IsOk = true;

            _err = default;
        }

        private Result(TErr err)
        {
            _err = err ?? throw new ArgumentNullException(nameof(err));
            IsOk = false;

            _ok = default;
        }

        public static Result<TOk, TErr> Ok(TOk ok) => new(ok);
        public static Result<TOk, TErr> Err(TErr err) => new(err);
    }
}