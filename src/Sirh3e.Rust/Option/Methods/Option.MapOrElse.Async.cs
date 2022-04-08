namespace Sirh3e.Rust.Option;

public partial struct Option<TSome>
{
    public Task<T> MapOrElseAsync<T>(Func<Task<T>> @default, Func<TSome, Task<T>> converter)
        => MatchAsync(converter, @default);
}