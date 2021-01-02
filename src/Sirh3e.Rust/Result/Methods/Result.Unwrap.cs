﻿using System;
using Sirh3e.Rust.Panic;

namespace Sirh3e.Rust.Result
{
    public readonly partial struct Result<TOk, TErr>
    {
        /// <summary>
        /// Returns the contained Ok value, consuming the self value.
        /// Because this function may panic, its use is generally discouraged. Instead, prefer to use pattern matching and handle the Err case explicitly, or call unwrap_or, unwrap_or_else, or unwrap_or_default
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="PanicException"></exception>
        public TOk Unwrap(string error)
        {
            if (IsOk)
            {
                return _ok;
            }

            if (string.IsNullOrEmpty(error))
            {
                throw new ArgumentNullException(nameof(error));
            }

            throw new PanicException(error);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public TOk Unwrap(Func<TErr, string> error)
        {
            if (error is null)
            {
                throw new ArgumentNullException(nameof(error));
            }

            return Unwrap(error(_err));
        }
    }
}