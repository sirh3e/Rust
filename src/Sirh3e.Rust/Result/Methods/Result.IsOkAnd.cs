namespace Sirh3e.Rust.Result;

public readonly partial struct Result<TOk, TErr>
{
    /// <summary>
    /// Returns true if the result is Ok wrapping a value matching the predicate.
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    [Docs("https://doc.rust-lang.org/std/result/enum.Result.html#method.is_ok_with")]
    [Unstable("is_some_with", 21)]
    public bool IsOkWith(Func<TOk, bool> predicate)
        => Match(predicate, _ => false);
}