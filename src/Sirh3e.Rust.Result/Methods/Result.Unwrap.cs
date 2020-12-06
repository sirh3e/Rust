﻿using System;

namespace Sirh3e.Rust.Result
{
    public readonly partial struct Result<TOk, TErr>
    {
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