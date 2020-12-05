﻿using System;
using Sirh3e.Rust.Option;

namespace Sirh3e.Rust.Result
{
    public readonly struct Result<T, E>
    {
        private readonly T _ok;
        private readonly E _err;

        public readonly bool IsOk;

        public bool IsErr => !IsOk;

        private Result(T ok)
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

        public static Result<T, E> Ok(T ok) => new(ok);
        public static Result<T, E> Err(E err) => new(err);

        public Option<T> Ok()
             => IsOk switch
             {
                 true => Option<T>.Some(_ok),
                 false => Option<T>.None,
             };

        public Option<E> Err()
            => IsErr switch
            {
                true => Option<E>.Some(_err),
                false => Option<E>.None,
            };

        public T Unwrap()
        {
            return Unwrap(error =>
            {
                return error switch
                {
                    _ => $"Cannot unwrap \"Ok\" when the result is \"Err\": {error}."
                };
            });
        }
        public T Unwrap(string error)
        {
            if (IsOk)
                return _ok;

            throw new ArgumentNullException(error);
        }

        public T Unwrap(Func<E, string> error)
        {
            if (IsOk)
                return _ok;

            if (error is null)
                throw new ArgumentNullException(nameof(error));
            throw new ArgumentException(error(_err));
        }
    }
}