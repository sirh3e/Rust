namespace Sirh3e.Rust.Result;

public readonly partial struct Result<TOk, TErr>
{
    /// <summary>
    ///     Returns the contained Ok value, consuming the self value, without checking that the value is not an Err.
    /// </summary>
    /// <returns></returns>
    [GitHub(23, "https://github.com/sirh3e/Rust/issues/23")]
    [Stable("option_result_unwrap_unchecked", "1.58.0")]
    [Docs("https://doc.rust-lang.org/std/option/enum.Option.html#method.unwrap_unchecked")]
    [Source("https://doc.rust-lang.org/src/core/result.rs.html#1491")]
    public TOk UnwrapUnchecked()
        => UnwrapOrElse(_ => default);
}