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

        public Result<U, TErr> Map<U>(Func<TOk, U> mapper)
        {
            if (!IsOk)
                return Result<U, TErr>.Err(_err);

            if (mapper is null)
                throw new ArgumentNullException(nameof(mapper));

            return new Result<U, TErr>(mapper(_ok));

        }

        public U MapOr<U>(U @default, Func<TOk, U> mapper)
        {
            if (!IsErr)
                return mapper(_ok);

            if (@default is null)
                throw new ArgumentNullException(nameof(@default));
            return @default;
        }

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

        public Result<TOk, F> MapErr<F>(Func<TErr, F> op)
        {
            if (IsOk)
            {
                return Result<TOk, F>.Ok(_ok);
            }

            if (op is null)
                throw new ArgumentNullException(nameof(op));

            return Result<TOk, F>.Err(op(_err));
        }

        public void Match(Action<TOk> onOk, Action<TErr> onErr)
        {
            if (IsOk)
            {
                if (onOk is null)
                    throw new ArgumentNullException(nameof(onOk));

                onOk(_ok);
            }
            else
            {
                if (onErr is null)
                    throw new ArgumentNullException(nameof(onErr));
                onErr(_err);
            }
        }

        public T Match<T>(Func<TOk, T> onOk, Func<TErr, string> onErr)
        {
            if (IsOk)
            {
                if (onOk is null)
                    throw new ArgumentNullException(nameof(onOk));
                return onOk(_ok);
            }

            if (onErr is null)
                throw new ArgumentNullException(nameof(onErr));
            throw new ArgumentException(onErr(_err));
        }
    }
}