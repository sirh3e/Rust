using System;
using Sirh3e.Rust.Option;

namespace Sirh3e.Rust.Result
{
    public readonly struct Result<TOk, E>
    {
        private readonly TOk _ok;
        private readonly E _err;

        public readonly bool IsOk;

        public bool IsErr => !IsOk;

        private Result(TOk ok)
        {
            _ok = ok ?? throw new ArgumentNullException(nameof(ok));
            IsOk = true;

            _err = default;
        }

        private Result(E err)
        {
            _err = err ?? throw new ArgumentNullException(nameof(err));
            IsOk = false;

            _ok = default;
        }

        public static Result<TOk, E> Ok(TOk ok) => new(ok);
        public static Result<TOk, E> Err(E err) => new(err);

        public Option<TOk> Ok()
             => IsOk switch
             {
                 true => Option<TOk>.Some(_ok),
                 false => Option<TOk>.None,
             };

        public Option<E> Err()
            => IsErr switch
            {
                true => Option<E>.Some(_err),
                false => Option<E>.None,
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

        public TOk Unwrap(Func<E, string> error)
        {
            if (IsOk)
                return _ok;

            if (error is null)
                throw new ArgumentNullException(nameof(error));
            throw new ArgumentException(error(_err));
        }
    }
}