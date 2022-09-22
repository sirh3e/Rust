namespace Sirh3e.Rust.Option;

public partial struct Option<TSome>
{
    /// <summary>
    ///     Returns true if the option is a Some wrapping a value matching the predicate.
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    [Pure]
    [Nightly]
    [GitHub(14, "https://github.com/sirh3e/Rust/issues/14")]
    [Docs("https://doc.rust-lang.org/std/option/enum.Option.html#method.is_some_and")]
    [Unstable("is_some_with", 93050)]
    [Source("https://doc.rust-lang.org/src/core/option.rs.html#576")]
    public bool IsSomeAnd(Func<TSome, bool> predicate)
        => Match(predicate, () => false);
}