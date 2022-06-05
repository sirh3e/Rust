namespace Sirh3e.Rust.Result;

public readonly partial struct Result<TOk, TErr>
{
    /// <summary>
    ///     Calls the provided closure with a reference to the contained value (if Ok).
    /// </summary>
    /// <param name="action"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    [Nightly]
    [GitHub(17, "https://github.com/sirh3e/Rust/issues/17")]
    [Docs("https://doc.rust-lang.org/std/result/enum.Result.html#method.inspect")]
    [Unstable("result_option_inspect", 91345)]
    [Source("https://doc.rust-lang.org/src/core/result.rs.html#874")]
    public Result<TOk, TErr> Inspect(Action<TOk> action)
    {
        if ( IsOk )
            (action ?? throw new ArgumentNullException(nameof(action)))(_ok);
        return this;
    }
}