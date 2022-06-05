namespace Sirh3e.Rust.Result;

public readonly partial struct Result<TOk, TErr>
{
    /// <summary>
    /// Returns the contained Ok value, consuming the self value, without checking that the value is not an Err.
    /// </summary>
    /// <returns></returns>
    public TOk UnwrapUnchecked()
        => UnwrapOrElse(_ => default);
}