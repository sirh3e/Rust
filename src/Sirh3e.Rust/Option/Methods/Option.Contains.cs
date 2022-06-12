namespace Sirh3e.Rust.Option;

public partial struct Option<TSome>
{
    /// <summary>
    ///     Returns true if the option is a Some value containing the given value.
    /// </summary>
    /// <param name="other"></param>
    /// <exception cref="ArgumentNullException">Throws ArgumentNullException when some is null</exception>
    /// <returns></returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [GitHub(31, "https://github.com/sirh3e/Rust/issues/31")]
    [Docs("https://doc.rust-lang.org/std/option/enum.Option.html#method.contains")]
    [Unstable("option_result_contains", 62358)]
    [Source("https://doc.rust-lang.org/src/core/option.rs.html#1621-1623")]
    public readonly bool Contains(TSome other)
        => Match(some => (some ?? throw new ArgumentNullException(nameof(some))).Equals(other), () => false);
}