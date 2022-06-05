namespace Sirh3e.Rust.Option;

public partial struct Option<TSome>
{
    /// <summary>
    ///     Inserts the default value into the option if it is None, then returns a mutable reference to the contained value.
    /// </summary>
    /// <returns></returns>
    [Nightly]
    [GitHub(12, "https://github.com/sirh3e/Rust/issues/12")]
    [Docs("https://doc.rust-lang.org/std/option/enum.Option.html#method.get_or_insert_default")]
    [Unstable("result_option_inspect", 91345)]
    [Source("https://doc.rust-lang.org/src/core/option.rs.html#936-939")]
    public TSome GetOrInsertDefault()
        => GetOrInsertWith(() => default);
}