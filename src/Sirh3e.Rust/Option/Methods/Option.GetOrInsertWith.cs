namespace Sirh3e.Rust.Option;

public partial struct Option<TSome>
{
    /// <summary>
    /// Inserts a value computed from func into the option if it is None, then returns a mutable reference to the contained value.
    /// </summary>
    /// <param name="func"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public TSome GetOrInsertWith(Func<TSome> func)
        => IsSome ? _some : Insert((_ = func ?? throw new ArgumentNullException())());
}