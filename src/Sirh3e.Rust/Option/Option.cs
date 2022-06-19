namespace Sirh3e.Rust.Option;

public partial struct Option<TSome> : ICloneable, IEnumerable<TSome>, IEquatable<Option<TSome>>
{
    public static Option<TSome> None => new();

    private TSome _some;

    private Option(TSome some)
    {
        _some = some;
        IsSome = Helper.IsSome(_some);
    }

    public override bool Equals(object? @object)
        => @object is Option<TSome> other && Equals(other);

    public bool Equals(Option<TSome> other)
            => IsNone == other.IsNone
           || EqualityComparer<TSome>.Default.Equals(_some, other._some);

    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();

    public IEnumerator<TSome> GetEnumerator()
#if NETCOREAPP1_0_OR_GREATER || NET46_OR_GREATER || NETSTANDARD1_3_OR_GREATER
        => new OptionEnumerator<TSome>(IsSome ? new[] { _some } : Array.Empty<TSome>());
#else
        => new OptionEnumerator<TSome>(IsSome ? new[] { _some } : new TSome[0]);
#endif

    public override int GetHashCode()
    {
#if NETCOREAPP2_1_OR_GREATER || NETSTANDARD2_1_OR_GREATER
        return HashCode.Combine(_some, IsSome);
#else
        //Thx to https://rehansaeed.com/gethashcode-made-easy/
        var hashCode = 17;

        hashCode = hashCode * 23 + (_some == null ? 0 : _some.GetHashCode());
        hashCode = hashCode * 23 + IsSome.GetHashCode();

        return hashCode;
#endif
    }

    public static implicit operator Option<TSome>(TSome? some)
        => some is not null
            ? Some(some)
            : None;

    public static Option<TSome> Some(TSome some)
        => new(some);

    public static implicit operator Option<TSome>(None none)
        => None;

    public static bool operator ==(Option<TSome> left, Option<TSome> right)
        => Equals(left, right);

    public static bool operator !=(Option<TSome> left, Option<TSome> right)
        => !(left == right);
}