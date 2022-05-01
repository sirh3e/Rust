namespace Sirh3e.Rust.Result;

public readonly partial struct Result<TOk, TErr>
{
    /// <summary>
    /// Calls the provided closure with a reference to the contained value (if Ok).
    /// </summary>
    /// <param name="action"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    [Docs("https://doc.rust-lang.org/std/result/enum.Result.html#method.inspect")]
    [Unstable("result_option_inspect", 17)]
    public Result<TOk, TErr> Inspect(Action<TOk> action)
    {
        if ( IsOk )
        {
            (action ?? throw new ArgumentNullException(nameof(action)))(_ok);
        }
        return this;
    }
}