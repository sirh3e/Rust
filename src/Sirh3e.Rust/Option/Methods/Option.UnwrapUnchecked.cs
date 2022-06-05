namespace Sirh3e.Rust.Option;

public partial struct Option<TSome>
{
    /// <summary>
    ///     Returns the contained Some value, consuming the self value, without checking that the value is not None.
    /// </summary>
    /// <returns></returns>
    [Nightly]
    [GitHub(15, "https://github.com/sirh3e/Rust/issues/15")]
    [Docs("https://doc.rust-lang.org/std/option/enum.Option.html#method.unwrap_unchecked")]
    [Unstable("const_option_ext", 91930)]
    [Source("https://doc.rust-lang.org/src/core/option.rs.html#874")]
    public TSome? UnwrapUnchecked()
        => Match(some => some, () => default);
}