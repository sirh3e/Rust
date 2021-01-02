﻿using System;
using Sirh3e.Rust.Panic;

namespace Sirh3e.Rust.Option
{
    public readonly partial struct Option<TSome>
    {
        /// <summary>
        /// Returns the contained Some value, consuming the self value.
        /// Because this function may panic, its use is generally discouraged. Instead, prefer to use pattern matching and handle the None case explicitly, or call unwrap_or, unwrap_or_else, or unwrap_or_default
        /// </summary>
        /// <returns></returns>
        public TSome Unwrap()
        {
            return Unwrap($"called `Option.Unwrap()` on a `None` value of type `{typeof(TSome)}`");
        }

        /// <summary>
        /// Returns the contained Some value, consuming the self value with custom error message.
        /// Because this function may panic, its use is generally discouraged. Instead, prefer to use pattern matching and handle the None case explicitly, or call unwrap_or, unwrap_or_else, or unwrap_or_default
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Throws only if error is null or empty</exception>
        public TSome Unwrap(string error)
        {
            if (string.IsNullOrEmpty(error))
                throw new ArgumentNullException(nameof(error));

            return Unwrap(() => error);
        }

        /// <summary>
        /// Returns the contained Some value, consuming the self value with custom error message.
        /// Because this function may panic, its use is generally discouraged. Instead, prefer to use pattern matching and handle the None case explicitly, or call unwrap_or, unwrap_or_else, or unwrap_or_default
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public TSome Unwrap(Func<string> error)
        {
            return Match(
                some => some,
                () => throw new PanicException(error() ??
                                               throw new ArgumentNullException(nameof(error)))
            );
        }
    }
}