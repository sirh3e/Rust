namespace Sirh3e.Rust.Option;

public readonly struct None : IEquatable<None>
{
    public static readonly None Value = default;

    public override bool Equals(object? @object)
        => @object is None other && Equals(other);

    public bool Equals(None other)
        => GetHashCode().Equals(other.GetHashCode());


    public override int GetHashCode()
        => -1;

    public static bool operator ==(None left, None right)
        => left.Equals(right);

    public static bool operator !=(None left, None right)
        => !(left == right);
}