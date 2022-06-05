namespace Sirh3e.Rust.Result;

public readonly partial struct Result<TOk, TErr>
{
    /// <summary>
    ///     Returns true if the result is Err wrapping a value matching the predicate.
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    [Nightly]
    [GitHub(20, "https://github.com/sirh3e/Rust/issues/20")]
    [Docs("https://doc.rust-lang.org/std/result/enum.Result.html#method.is_err_and")]
    [Unstable("is_some_with", 20)]
    [Source("https://doc.rust-lang.org/src/core/result.rs.html#610")]
    public bool IsErrAnd(Func<TErr, bool> predicate)
        => Match(_ => false, predicate);
}