using System;

namespace Sirh3e.Rust.Option
{
    public readonly struct None : IEquatable<None>
    {
        public static readonly None Value = default;

        public bool Equals(None other)
        {
            return GetHashCode().Equals(other.GetHashCode());
        }

        public override bool Equals(object obj)
        {
            return obj is None other && Equals(other);
        }

        public override int GetHashCode()
        {
            return -1;
        }

        public static bool operator ==(None left, None right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(None left, None right)
        {
            return !left.Equals(right);
        }
    }
}