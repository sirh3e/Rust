namespace Sirh3e.Rust.Option;

public partial struct Option<TSome>
{
    /// <summary>
    /// Returns true if the option is a None value.
    /// </summary>
    [Pure]
    [GitHub(38, "https://github.com/sirh3e/Rust/issues/38")]
    [Docs("https://doc.rust-lang.org/std/option/enum.Option.html#method.is_none")]
    [Stable("const_option_basics", "1.48.0")]
    [Source("https://doc.rust-lang.org/src/core/option.rs.html#596")]
    public readonly bool IsNone => IsSome == false;
}