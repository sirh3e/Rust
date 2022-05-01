namespace Sirh3e.Rust.Result;

public readonly ref struct Err<TErr>
{
    internal readonly TErr Value;

    public Err(TErr err)
    {
        Value = err ?? throw new ArgumentNullException(nameof(err));
    }
}