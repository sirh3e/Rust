namespace Sirh3e.Rust.Option;

public partial struct Option<TSome>
{
    /// <summary>
    ///     Returns None if the option is None, otherwise calls predicate with the wrapped value and returns:
    ///     [Some(TSome)] if predicate returns true (where t is the wrapped value), and None if predicate returns false.
    ///     This function works similar to Iterator::filter(). You can imagine the Option&lt;TSome&gt; being an iterator over
    ///     one or zero elements. filter() lets you decide which elements to keep.
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">Throws only if predicate is null</exception>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [GitHub(34, "https://github.com/sirh3e/Rust/issues/34")]
    [Docs("https://doc.rust-lang.org/std/option/enum.Option.html#method.filter")]
    [Unstable("const_option_ext", 91930)]
    [Source("https://doc.rust-lang.org/src/core/option.rs.html#1285-1289")]
    public Option<TSome> Filter(Func<TSome, bool> predicate)
        => IsSome
            ? (predicate ?? throw new ArgumentNullException(nameof(predicate)))(_some)
                ? Some(_some)
                : None
            : None;
}