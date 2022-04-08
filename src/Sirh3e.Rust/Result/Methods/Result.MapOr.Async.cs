namespace Sirh3e.Rust.Result;

public readonly partial struct Result<TOk, TErr>
{
    public Task<T> MapOrAsync<T>(T @default, Func<TOk, Task<T>> map)
        => MatchAsync(map, _ => @default);
}