namespace Sirh3e.Rust.Option;

public partial struct Option<TSome>
{
    /// <summary>
    ///     Consumes self while expecting None and returning nothing.
    /// </summary>
    /// <param name="message"></param>
    /// <exception cref="PanicException">Panics if the value is a Some with a custom panic message provided by message.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [GitHub(33, "https://github.com/sirh3e/Rust/issues/33")]
    public readonly void ExpectNone(string message)
        => Match(some => ExpectNoneFailed(message, some), _ => { });
}