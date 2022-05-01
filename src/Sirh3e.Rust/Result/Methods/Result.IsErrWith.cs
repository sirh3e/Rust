namespace Sirh3e.Rust.Result;

public readonly partial struct Result<TOk, TErr>
{
    /// <summary>
    /// Returns true if the result is Err wrapping a value matching the predicate.
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    [Docs("https://doc.rust-lang.org/std/result/enum.Result.html#method.is_err_with")]
    [Unstable("is_some_with", 20)]
    public bool IsErrWith(Func<TErr, bool> predicate)
        => Match(_ => false, predicate);
}