using System;
using System.Collections;
using System.Collections.Generic;

namespace Sirh3e.Rust.Option
{
    public partial struct Option<TSome> : ICloneable, IEnumerable<TSome>, IEquatable<Option<TSome>>
    {
        private TSome _some;

        public static Option<TSome> None => new();

        private Option(TSome some)
        {
            _some = some;
            IsSome = Helper.IsSome(_some);
        }

        public override bool Equals(object? @object)
            => @object is Option<TSome> other && Equals(other);

        public bool Equals(Option<TSome> other)
            => EqualityComparer<TSome>.Default.Equals(_some, other._some) &&
               IsSome == other.IsSome;

        public static Option<TSome> Some(TSome some)
            => new(some);

        public static implicit operator Option<TSome>(None none)
            => None;

        public IEnumerator<TSome> GetEnumerator()
            => new OptionEnumerator<TSome>(IsSome ? new[] { _some } : new TSome[0]);

        public override int GetHashCode()
        {
#if NET2_1_OR_GREATER
            return HashCode.Combine(_some, IsSome);
#else
            //Thx to https://rehansaeed.com/gethashcode-made-easy/
            var hashCode = 17;

            hashCode = hashCode * 23 + (_some == null ? 0 : _some.GetHashCode());
            hashCode = hashCode * 23 + IsSome.GetHashCode();

            return hashCode;
#endif
        }

        public Option<TSome> Clone()
            => IsSome ? Some(_some) : None;

        object ICloneable.Clone()
            => Clone();

        IEnumerator IEnumerable.GetEnumerator()
            => Iter();

        public static bool operator ==(Option<TSome> left, Option<TSome> right)
            => Equals(left, right);

        public static bool operator !=(Option<TSome> left, Option<TSome> right)
            => !(left == right);
    }
}