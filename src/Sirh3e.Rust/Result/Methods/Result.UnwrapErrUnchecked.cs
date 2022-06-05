namespace Sirh3e.Rust.Result;

public readonly partial struct Result<TOk, TErr>
{
    /// <summary>
    ///     Returns the contained Err value, consuming the self value, without checking that the value is not an Ok.
    /// </summary>
    /// <returns></returns>
    [GitHub(22, "https://github.com/sirh3e/Rust/issues/22")]
    [Docs("https://doc.rust-lang.org/std/result/enum.Result.html#method.unwrap_err_unchecked")]
    [Stable("option_result_unwrap_unchecked", "1.58.0")]
    [Source("https://doc.rust-lang.org/src/core/result.rs.html#1523")]
    public TErr UnwrapErrUnchecked()
        => Match(_ => default, err => err);
}