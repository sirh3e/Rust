﻿using System;

namespace Sirh3e.Rust.Option
{
    public readonly partial struct Option<TSome>
    {
        public T MapOr<T>(T @default, Func<TSome, T> converter)
        {
            return Match(
                some => converter(some) ?? throw new ArgumentNullException(nameof(converter)),
                () => @default ?? throw new ArgumentNullException(nameof(@default))
            );
        }
    }
}