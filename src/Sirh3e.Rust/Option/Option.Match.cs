namespace Sirh3e.Rust.Option;

public partial struct Option<TSome>
{
    /// <summary>
    ///     Control flow based on pattern matching.
    ///     match can be used to run code conditionally. Every pattern must be handled exhaustively either explicitly or by
    ///     using wildcards like _ in the match. Since match is an expression, values can also be returned.
    /// </summary>
    /// <param name="onSome"> Do a action when Option is Some with Some value provided</param>
    /// <param name="onNone"> Do a action when Option is None</param>
    /// <exception cref="ArgumentNullException">Throws ArgumentNullException when onSome or onNone is null</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [GitHub(27, "https://github.com/sirh3e/Rust/issues/27")]
    [Docs("https://doc.rust-lang.org/std/keyword.match.html")]
    [Keyword("match_keyword")]
    [Source("https://doc.rust-lang.org/src/std/keyword_docs.rs.html#966")]
    public readonly void Match(Action<TSome> onSome, Action onNone)
    {
        if ( IsSome )
            (onSome ?? throw new ArgumentNullException(nameof(onSome)))(_some);
        else
            (onNone ?? throw new ArgumentNullException(nameof(onNone)))();
    }

    /// <summary>
    ///     Control flow based on pattern matching.
    ///     match can be used to run code conditionally. Every pattern must be handled exhaustively either explicitly or by
    ///     using wildcards like _ in the match. Since match is an expression, values can also be returned.
    /// </summary>
    /// <param name="onSome"></param>
    /// <param name="onNone"></param>
    /// <exception cref="ArgumentNullException">Throws ArgumentNullException when onSome or onNone is null</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [GitHub(27, "https://github.com/sirh3e/Rust/issues/27")]
    [Docs("https://doc.rust-lang.org/std/keyword.match.html")]
    [Keyword("match_keyword")]
    [Source("https://doc.rust-lang.org/src/std/keyword_docs.rs.html#966")]
    private readonly void Match(Action<TSome> onSome, Action<TSome> onNone)
        => (IsSome
            ? onSome ?? throw new ArgumentNullException(nameof(onSome))
            : onNone ?? throw new ArgumentNullException(nameof(onNone)))(_some);

    /// <summary>
    ///     Control flow based on pattern matching.
    ///     match can be used to run code conditionally. Every pattern must be handled exhaustively either explicitly or by
    ///     using wildcards like _ in the match. Since match is an expression, values can also be returned.
    /// </summary>
    /// <param name="onSome"> Maps the TSome type to T when Option is Some</param>
    /// <param name="onNone"> Provides the type of T when Option is None</param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">Throws ArgumentNullException when onSome or onNone is null</exception>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [GitHub(27, "https://github.com/sirh3e/Rust/issues/27")]
    [Docs("https://doc.rust-lang.org/std/keyword.match.html")]
    [Keyword("match_keyword")]
    [Source("https://doc.rust-lang.org/src/std/keyword_docs.rs.html#966")]
    public readonly T Match<T>(Func<TSome, T> onSome, Func<T> onNone)
        => IsSome
            ? (onSome ?? throw new ArgumentNullException(nameof(onSome)))(_some)
            : (onNone ?? throw new ArgumentNullException(nameof(onNone)))();
}