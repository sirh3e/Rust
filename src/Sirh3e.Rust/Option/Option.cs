using System;
using System.Collections;
using System.Collections.Generic;
#if !NET2_0_OR_GREATER
using System.Reflection;
#endif

namespace Sirh3e.Rust.Option
{
    public readonly partial struct Option<TSome> : ICloneable, IEnumerable<TSome>, IEquatable<Option<TSome>>
    {
        private readonly TSome _some;
        public static Option<TSome> None => new();

        private Option(TSome some)
        {
            _some = some;

            var isValueType = false;
            
#if NET2_0_OR_GREATER
            isValueType = typeof(TSome).IsValueType;
#else
            isValueType = typeof(TSome).GetTypeInfo().IsValueType;
#endif
            IsSome = isValueType || some != null;
        }

        public bool Equals(Option<TSome> other)
        {
            return EqualityComparer<TSome>.Default.Equals(_some, other._some) && IsSome == other.IsSome;
        }

        public static Option<TSome> Some(TSome some)
        {
            return new(some);
        }


        public static implicit operator Option<TSome>(None none)
        {
            return None;
        }

        public IEnumerator<TSome> GetEnumerator()
        {
            return new OptionEnumerator<TSome>(IsSome ? new[] { _some } : new TSome[0]);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj.GetType() == GetType() && Equals((Option<TSome>)obj);
        }

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
        {
            return IsSome ? Some(_some) : None;
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public static bool operator ==(Option<TSome> left, Option<TSome> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Option<TSome> left, Option<TSome> right)
        {
            return !Equals(left, right);
        }
    }
}