using System;
using System.Collections.Generic;

namespace Sirh3e.Rust.Option
{
    public readonly partial struct Option<TSome> : IEquatable<Option<TSome>>
    {
        private readonly TSome _some;
        public static Option<TSome> None => new();

        private Option(TSome some)
        {
            _some = some;
            IsSome = typeof(TSome).IsValueType || some != null;
        }

        public bool Equals(Option<TSome> other)
        {
            return EqualityComparer<TSome>.Default.Equals(_some, other._some) && IsSome == other.IsSome;
        }

        public static Option<TSome> Some(TSome some)
        {
            return new(some);
        }

        public TSome Unwrap()
        {
            return Unwrap(() => $"Cannot unwrap \"None\" of type {typeof(TSome)}.");
        }

        public static implicit operator Option<TSome>(None none)
        {
            return None;
        }

        public TSome Unwrap(Func<string> error)
        {
            if (IsSome)
                return Unwrap(error.Invoke());

            if (error is null)
                throw new ArgumentNullException(nameof(error));

            throw new NotImplementedException(); //ToDo create own exception
        }

        public TSome Unwrap(string error)
        {
            if (string.IsNullOrEmpty(error))
                throw new ArgumentNullException(nameof(error));

            if (IsNone)
                throw new NotImplementedException(error); //ToDo create own exception

            return _some;
        }

        public TSome UnwrapOr(TSome other)
        {
            return IsSome ? _some : other;
        }

        public TSome UnwrapOrElse(Func<TSome> alternative)
        {
            if (IsSome)
                return _some;

            return alternative() ?? throw new ArgumentNullException(nameof(alternative));
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Option<TSome>)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_some, IsSome);
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