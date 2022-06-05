namespace Sirh3e.Rust.Result;

public readonly partial struct Result<TOk, TErr>
{
    /// <summary>
    ///     Returns true if the result is Ok wrapping a value matching the predicate.
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    [Nightly]
    [GitHub(21, "https://github.com/sirh3e/Rust/issues/21")]
    [Docs("https://doc.rust-lang.org/std/result/enum.Result.html#method.is_ok_and")]
    [Unstable("is_some_with", 93050)]
    [Source("https://doc.rust-lang.org/src/core/result.rs.html#565")]
    public bool IsOkAnd(Func<TOk, bool> predicate)
        => Match(predicate, _ => false);
}