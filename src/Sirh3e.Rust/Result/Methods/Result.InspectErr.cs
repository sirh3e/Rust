namespace Sirh3e.Rust.Result;

public readonly partial struct Result<TOk, TErr>
{
    /// <summary>
    /// Calls the provided closure with a reference to the contained error (if Err).
    /// </summary>
    /// <param name="action"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    [Docs("https://doc.rust-lang.org/std/result/enum.Result.html#method.inspect")]
    [Unstable("result_option_inspect", 18)]
    public Result<TOk, TErr> InspectErr(Action<TErr> action)
    {
        if ( IsErr )
        {
            (action ?? throw new ArgumentNullException(nameof(action)))(_err);
        }
        return this;
    }
}