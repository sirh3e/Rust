using System.Collections;
using System.Collections.Generic;

namespace Sirh3e.Rust.Result
{
    public readonly partial struct Result<TOk, TErr> : ICloneable, IEnumerable<TOk>, IEquatable<Result<TOk, TErr>>
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
            => EqualityComparer<TOk>.Default.Equals(_ok, other._ok) &&
               EqualityComparer<TErr>.Default.Equals(_err, other._err) &&
               IsOk == other.IsOk;

        public IEnumerator<TOk> GetEnumerator()
#if NET1_1_OR_GREATER
            => new ResultEnumerator<TOk>(IsOk ? new[] { _ok } : Array.Empty<TOk>());
#else
            => new ResultEnumerator<TOk>(IsOk ? new[] { _ok } : new TOk[0]);
#endif

        public override bool Equals(object obj)
            => obj is Result<TOk, TErr> other && Equals(other);

        public override int GetHashCode()
        {
#if NET2_1_OR_GREATER
            return HashCode.Combine(_ok, _err, IsOk);
#else
            //Thx to https://rehansaeed.com/gethashcode-made-easy/
            var hashCode = 17;

            hashCode = hashCode * 23 + (_ok == null ? 0 : _ok.GetHashCode());
            hashCode = hashCode * 23 + (_err == null ? 0 : _err.GetHashCode());
            hashCode = hashCode * 23 + IsErr.GetHashCode();

            return hashCode;
#endif
        }

        IEnumerator IEnumerable.GetEnumerator()
            => Iter();

        public Result<TOk, TErr> Clone()
            => IsOk ? Ok(_ok) : Err(_err);

        object ICloneable.Clone()
            => Clone();

        public static implicit operator Result<TOk, TErr>(Err<TErr> err)
            => Err(err.Value);

        public static implicit operator Result<TOk, TErr>(Ok<TOk> ok)
            => Ok(ok.Value);

        public static bool operator ==(Result<TOk, TErr> left, Result<TOk, TErr> right)
            => left.Equals(right);

        public static bool operator !=(Result<TOk, TErr> left, Result<TOk, TErr> right)
            => !(left == right);
    }
}