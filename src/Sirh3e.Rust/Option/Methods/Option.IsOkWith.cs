namespace Sirh3e.Rust.Option;

public partial struct Option<TSome>
{
    /// <summary>
    /// Returns true if the option is a Some wrapping a value matching the predicate.
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    [Unstable("is_some_with", 21)]
    [Docs("https://doc.rust-lang.org/std/result/enum.Result.html#method.is_ok_with")]
    public bool IsOkWith(Func<TSome, bool> predicate)
        => Match(predicate, () => false);
}