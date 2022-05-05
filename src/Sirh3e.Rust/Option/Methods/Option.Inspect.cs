namespace Sirh3e.Rust.Option;

public partial struct Option<TSome>
{
    /// <summary>
    /// Calls the provided closure with a reference to the contained value (if Some).
    /// </summary>
    /// <param name="inspector"></param>
    /// <returns></returns>
    public Option<TSome> Inspect(Action<TSome> inspector)
    {
        if ( IsSome )
        {
            inspector(_some);
        }
        return this;
    }
}