namespace Sirh3e.Rust.Result;

public readonly partial struct Result<TOk, TErr>
{
    /// <summary>
    /// Returns true if the result is an Err value containing the given value.
    /// </summary>
    /// <param name="err"></param>
    /// <returns>Returns true if the result is an Err value containing the given value.</returns>
    public bool ContainsErr(TErr err)
        => err != null && IsErr && err.Equals(_err);
}