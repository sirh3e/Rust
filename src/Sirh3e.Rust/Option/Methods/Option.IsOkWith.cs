namespace Sirh3e.Rust.Option;

public partial struct Option<TSome>
{
    /// <summary>
    /// Returns true if the option is a Some wrapping a value matching the predicate.
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public bool IsOkWith(Func<TSome, bool> predicate)
        => Match(predicate, () => false);
}