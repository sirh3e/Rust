namespace Sirh3e.Rust.Result;

public readonly partial struct Result<TOk, TErr>
{
    public Task<T> MapOrElseAsync<T>(Func<TErr, Task<T>> @default, Func<TOk, Task<T>> map)
        => MatchAsync(map, @default);
}