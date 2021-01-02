﻿using System;
using System.Collections.Generic;

namespace Sirh3e.Rust.Result
{
    public readonly partial struct Result<TOk, TErr> : ICloneable, IEquatable<Result<TOk, TErr>>
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

        public static Result<TOk, TErr> Ok(TOk ok)
            => new(ok);
        public static Result<TOk, TErr> Err(TErr err)
            => new(err);

        public bool Equals(Result<TOk, TErr> other)
        {
            return EqualityComparer<TOk>.Default.Equals(_ok, other._ok) &&
                   EqualityComparer<TErr>.Default.Equals(_err, other._err) &&
                   IsOk == other.IsOk;
        }

        public override bool Equals(object obj)
        {
            return obj is Result<TOk, TErr> other &&
                   Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_ok, _err, IsOk);
        }

        public Result<TOk, TErr> Clone()
        {
            return Cloned();
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public static bool operator ==(Result<TOk, TErr> left, Result<TOk, TErr> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Result<TOk, TErr> left, Result<TOk, TErr> right)
        {
            return !left.Equals(right);
        }
    }
}