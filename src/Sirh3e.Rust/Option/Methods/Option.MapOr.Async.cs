namespace Sirh3e.Rust.Option;

public partial struct Option<TSome>
{
    public Task<T> MapOrAsync<T>(T @default, Func<TSome, Task<T>> converter)
        => MatchAsync(converter, () => Task.FromResult(@default));
}