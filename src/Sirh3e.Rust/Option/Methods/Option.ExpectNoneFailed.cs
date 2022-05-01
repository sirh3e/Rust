namespace Sirh3e.Rust.Option;

public partial struct Option<TSome>
{
    private static void ExpectNoneFailed<T>(string message, T some)
        => throw new PanicException($"{message ?? throw new ArgumentNullException(nameof(message))}: {some ?? throw new ArgumentNullException(nameof(some))}");
}