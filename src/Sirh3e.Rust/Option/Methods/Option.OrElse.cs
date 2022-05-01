namespace Sirh3e.Rust.Option;

public partial struct Option<TSome>
{
    /// <summary>
    /// Returns the option if it contains a value, otherwise calls func and returns the result. 
    /// </summary>
    /// <param name="func"></param>
    /// <returns></returns>
    public Option<TSome> OrElse(Func<Option<TSome>> func)
        => Match(Some, func ?? throw new ArgumentNullException(nameof(func)));
}