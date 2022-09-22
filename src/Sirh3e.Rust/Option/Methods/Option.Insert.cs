namespace Sirh3e.Rust.Option;

public partial struct Option<TSome>
{
    /// <summary>
    /// Inserts value into the option then returns a mutable reference to it.
    /// If the option already contains a value, the old value is dropped / disposed.
    /// </summary>
    /// <param name="some"></param>
    /// <returns>Returns the inserted value back</returns>
    /// <exception cref="ArgumentNullException">If the inserted value is null</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [GitHub(37, "https://github.com/sirh3e/Rust/issues/37")]
    [Docs("https://doc.rust-lang.org/std/option/enum.Option.html#method.insert")]
    [Stable("option_insert", "1.53.0")]
    [Source("https://doc.rust-lang.org/src/core/option.rs.html#1437-1439")]
    public TSome Insert(TSome some)
    {
        _ = some ?? throw new ArgumentNullException(nameof(some));

        if ( IsSome )
        {
            {
                if ( _some is IAsyncDisposable disposable )
                {
                    var task = disposable.DisposeAsync();
                    task.GetAwaiter().GetResult();

                    goto set_some;
                }
            }
            {
                if ( _some is IDisposable disposable )
                    disposable.Dispose();
                goto set_some;
            }
        }

    set_some:
        SetSome(some);

        return _some;
    }
}