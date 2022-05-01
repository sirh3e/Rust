namespace Sirh3e.Rust.Result;

public readonly partial struct Result<TOk, TErr>
{
    /// <summary>
    /// Returns the contained Ok value, but never panics.
    /// </summary>
    /// <returns></returns>
    public TOk IntoOk() => _ok;
}