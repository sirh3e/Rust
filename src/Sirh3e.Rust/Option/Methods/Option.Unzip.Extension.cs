namespace Sirh3e.Rust.Option;

public static partial class OptionExtension
{
    /// <summary>
    ///     Unzips an option containing a tuple of two options.
    ///     If self is Some((a, b)) this method returns (Some(a), Some(b)). Otherwise, (None, None) is returned.
    /// </summary>
    /// <param name="option"></param>
    /// <typeparam name="TLhs"></typeparam>
    /// <typeparam name="TRhs"></typeparam>
    /// <returns></returns>
    [Nightly]
    [GitHub(16, "https://github.com/sirh3e/Rust/issues/16")]
    [Docs("https://doc.rust-lang.org/std/option/enum.Option.html#method.unzip")]
    [Unstable("unzip_option", 87800, "recently added")]
    [Source("https://doc.rust-lang.org/src/core/option.rs.html#1724")]
    public static (Option<TLhs>, Option<TRhs>) Unzip<TLhs, TRhs>(this Option<(TLhs, TRhs)> option)
        => option.Match(t => (Option<TLhs>.Some(t.Item1), Option<TRhs>.Some(t.Item2)),
                        () => (Option<TLhs>.None, Option<TRhs>.None));
}