namespace Sirh3e.Rust.Option;

public partial struct Option<TSome>
{
    /// <summary>
    ///     Calls the provided closure with a reference to the contained value (if Some).
    /// </summary>
    /// <param name="inspector"></param>
    /// <returns></returns>
    [Nightly]
    [GitHub(13, "https://github.com/sirh3e/Rust/issues/13")]
    [Docs("https://doc.rust-lang.org/std/option/enum.Option.html#method.inspect")]
    [Unstable("result_option_inspect", 91345)]
    [Source("https://doc.rust-lang.org/src/core/option.rs.html#936-939")]
    public Option<TSome> Inspect(Action<TSome> inspector)
    {
        if ( IsSome ) inspector(_some);
        return this;
    }
}