namespace Sirh3e.Rust.Option;

public static partial class OptionExtension
{
    /// <summary>
    ///     Converts from Option<Option<T>> to Option<T>.
    /// </summary>
    /// <param name="option"></param>
    /// <typeparam name="TSome"></typeparam>
    /// <returns></returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [GitHub(35, "https://github.com/sirh3e/Rust/issues/35")]
    [Docs("https://doc.rust-lang.org/std/option/enum.Option.html#method.flatten")]
    [Stable("option_flattening", "1.40.0")]
    [Source("https://doc.rust-lang.org/src/core/option.rs.html#2343")]
    public static Option<TSome> Flatten<TSome>(this Option<Option<TSome>> option)
        => option.IsNone
            ? Option<TSome>.None
            : option.Unwrap();
}