namespace Sirh3e.Rust.Option;

public partial struct Option<TSome>
{
    private static TSome ExpectFailed(string message)
        => throw new PanicException(message ?? throw new ArgumentNullException(nameof(message)));
}