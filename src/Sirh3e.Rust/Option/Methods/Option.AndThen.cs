namespace Sirh3e.Rust.Option;

public partial struct Option<TSome>
{
    /// <summary>
    ///     Returns None if the option is None, otherwise calls func with the wrapped value and returns the result.
    ///     Some languages call this operation flatmap.
    /// </summary>
    /// <param name="func"></param>
    /// <returns></returns>
    [Pure]
    [GitHub(25, "https://github.com/sirh3e/Rust/issues/25")]
    [Docs("https://doc.rust-lang.org/std/option/enum.Option.html#method.and_then")]
    [Stable("rust1", "1.0.0")]
    [Source("https://doc.rust-lang.org/src/core/option.rs.html#1246-1249")]
    public readonly Option<TSome> AndThen(Func<TSome, Option<TSome>> func)
        => Match(func, () => None);
}