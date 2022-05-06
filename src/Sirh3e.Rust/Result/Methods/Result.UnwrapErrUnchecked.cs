namespace Sirh3e.Rust.Result;

public readonly partial struct Result<TOk, TErr>
{
    /// <summary>
    /// Returns the contained Err value, consuming the self value, without checking that the value is not an Ok.
    /// </summary>
    /// <returns></returns>
    public TErr UnwrapErrUnchecked()
        => Match(_ => default, err => err);
}