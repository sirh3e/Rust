namespace Sirh3e.Rust.Result;

public readonly partial struct Result<TOk, TErr>
{
    /// <summary>
    /// Returns the contained Err value, consuming the self value.
    /// </summary>
    /// <returns></returns>
    public TErr UnwrapErr()
    {
        return UnwrapErr(ok =>
        {
            return ok switch
            {
                _ => $"Cannot unwrap \"Err\" when the result is \"Ok\": {ok}."
            };
        });
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="PanicException"></exception>
    public TErr UnwrapErr(string message)
    {
        if ( IsErr )
        {
            return _err;
        }

        if ( string.IsNullOrEmpty(message) )
        {
            throw new ArgumentNullException(nameof(message));
        }

        throw new PanicException(message);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ok"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public TErr UnwrapErr(Func<TOk, string> ok)
        => UnwrapErr((_ = ok ?? throw new ArgumentNullException(nameof(ok)))(_ok));
}