namespace Sirh3e.Rust.Option;

public partial struct Option<TSome>
{
    /// <summary>
    /// Returns true if the option is a Some value.
    /// </summary>
    [GitHub(39, "https://github.com/sirh3e/Rust/issues/39")]
    [Docs("https://doc.rust-lang.org/std/option/enum.Option.html#method.is_some")]
    [Stable("const_option_basics", "1.48.0")]
    [Source("https://doc.rust-lang.org/src/core/option.rs.html#553")]
    public bool IsSome { get; private set; }
}