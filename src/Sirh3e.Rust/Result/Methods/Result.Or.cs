namespace Sirh3e.Rust.Result;

public readonly partial struct Result<TOk, TErr>
{
    /// <summary>
    /// Returns res if the result is Err, otherwise returns the Ok value of self.
    /// Arguments passed to or are eagerly evaluated; if you are passing the result of a function call, it is recommended to use or_else, which is lazily evaluated.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public Result<TOk, TErr> Or(Result<TOk, TErr> other)
        => IsOk ? this : other;
}