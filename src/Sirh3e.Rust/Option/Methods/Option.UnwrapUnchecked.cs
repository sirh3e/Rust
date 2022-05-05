namespace Sirh3e.Rust.Option;

public partial struct Option<TSome>
{
    /// <summary>
    /// Returns the contained Some value, consuming the self value, without checking that the value is not None.
    /// </summary>
    /// <returns></returns>
    public TSome? UnwrapUnchecked()
        => Match(some => some, () => default);
}