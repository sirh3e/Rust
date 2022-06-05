namespace Sirh3e.Rust.Result;

public readonly partial struct Result<TOk, TErr>
{
    /// <summary>
    ///     Calls the provided closure with a reference to the contained error (if Err).
    /// </summary>
    /// <param name="action"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    [Nightly]
    [GitHub(18, "https://github.com/sirh3e/Rust/issues/18")]
    [Docs("https://doc.rust-lang.org/std/result/enum.Result.html#method.inspect_err")]
    [Unstable("result_option_inspect", 91345)]
    [Source("https://doc.rust-lang.org/src/core/result.rs.html#898")]
    public Result<TOk, TErr> InspectErr(Action<TErr> action)
    {
        if ( IsErr )
            (action ?? throw new ArgumentNullException(nameof(action)))(_err);
        return this;
    }
}