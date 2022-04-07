namespace Sirh3e.Rust.Option;

public partial struct Option<TSome>
{
    public Task<Option<T>> MapAsync<T>(Func<TSome, Task<T>> map)
        => MatchAsync(async ok => new Option<T>(await map(ok)), () => Option<T>.None);
}