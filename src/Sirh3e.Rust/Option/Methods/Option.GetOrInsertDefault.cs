namespace Sirh3e.Rust.Option;

public partial struct Option<TSome>
{
    /// <summary>
    /// Inserts the default value into the option if it is None, then returns a mutable reference to the contained value.
    /// </summary>
    /// <returns></returns>
    public TSome GetOrInsertDefault()
        => GetOrInsertWith(() => default);
}