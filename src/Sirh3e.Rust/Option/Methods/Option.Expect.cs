namespace Sirh3e.Rust.Option;

public partial struct Option<TSome>
{
    /// <summary>
    ///     Returns the contained Some value, consuming the self value.
    ///     Panics
    ///     Panics if the value is a None with a custom panic message provided by msg.
    /// </summary>
    /// <param name="message"></param>
    /// <exception cref="PanicException">Panics if the value is a None with a custom panic message provided by msg.</exception>
    /// <returns></returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [GitHub(32, "https://github.com/sirh3e/Rust/issues/32")]
    [Docs("https://doc.rust-lang.org/std/option/enum.Option.html#method.expect")]
    [Unstable("const_option", 67441)]
    [Source("https://doc.rust-lang.org/src/core/option.rs.html#715")]
    public TSome Expect(string message)
        => Match(some => some, () => ExpectFailed(message));
}