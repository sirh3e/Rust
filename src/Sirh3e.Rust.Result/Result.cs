using System;
using Sirh3e.Rust.Option;

namespace Sirh3e.Rust.Result
{
    public readonly struct Result<TOk, TErr>
    {
        private readonly TOk _ok;
        private readonly TErr _err;

        public readonly bool IsOk;

        public bool IsErr => !IsOk;

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

        public Option<TOk> Ok()
             => IsOk switch
             {
                 true => Option<TOk>.Some(_ok),
                 false => Option<TOk>.None,
             };

        public Option<TErr> Err()
            => IsErr switch
            {
                true => Option<TErr>.Some(_err),
                false => Option<TErr>.None,
            };

        public TOk Unwrap()
        {
            return Unwrap(error =>
            {
                return error switch
                {
                    _ => $"Cannot unwrap \"Ok\" when the result is \"Err\": {error}."
                };
            });
        }

        public TOk Unwrap(string error)
        {
            if (IsOk)
                return _ok;

            throw new ArgumentNullException(error);
        }

        public TOk Unwrap(Func<TErr, string> error)
        {
            if (IsOk)
                return _ok;

            if (error is null)
                throw new ArgumentNullException(nameof(error));
            throw new ArgumentException(error(_err));
        }
    }
}