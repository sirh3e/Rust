﻿using System;

namespace Sirh3e.Rust.Result
{
    public readonly partial struct Result<TOk, TErr>
    {
        /// <summary>
        /// Applies a function to the contained value (if Ok), or returns the provided default (if Err).
        /// Arguments passed to map_or are eagerly evaluated; if you are passing the result of a function call, it is recommended to use map_or_else, which is lazily evaluated.
        /// </summary>
        /// <param name="default"></param>
        /// <param name="map"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Throws only if map is null or default is null</exception>
        public T MapOr<T>(T @default, Func<TOk, T> map)
        {
            return Match(ok =>
            {
                if (map is null)
                    throw new ArgumentNullException(nameof(map));
                return map(ok);
            }, _ =>
            {
                if (@default is null)
                    throw new ArgumentNullException(nameof(@default));
                return @default;
            });
        }
    }
}