namespace Sirh3e.Rust.Result;

public readonly partial struct Result<TOk, TErr>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="onOk"></param>
    /// <param name="onErr"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public void Match(Action<TOk> onOk, Action<TErr> onErr)
    {
        if ( IsOk )
            (onOk ?? throw new ArgumentNullException(nameof(onOk)))(_ok);
        else
            (onErr ?? throw new ArgumentNullException(nameof(onErr)))(_err);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="onOk"></param>
    /// <param name="onErr"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public T Match<T>(Func<TOk, T> onOk, Func<TErr, T> onErr)
        => IsOk
            ? (onOk ?? throw new ArgumentNullException(nameof(onOk)))(_ok)
            : (onErr ?? throw new ArgumentNullException(nameof(onErr)))(_err);
}