namespace Sirh3e.Rust.Result;

public static partial class ResultExtension
{
    /// <summary>
    /// Unzips an option containing a tuple of two options.
    /// If self is Some((a, b)) this method returns (Some(a), Some(b)). Otherwise, (None, None) is returned.
    /// </summary>
    /// <param name="option"></param>
    /// <typeparam name="TLhs"></typeparam>
    /// <typeparam name="TRhs"></typeparam>
    /// <returns></returns>
    [Docs("https://doc.rust-lang.org/std/option/enum.Option.html#method.unzip")]
    [Unstable("unzip_option", 16)]
    public static (Option<TLhs>, Option<TRhs>) Unzip<TLhs, TRhs>(this Option<(TLhs, TRhs)> option)
        => option.Match(t => (Option<TLhs>.Some(t.Item1), Option<TRhs>.Some(t.Item2)),
                        () => (Option<TLhs>.None, Option<TRhs>.None));
}