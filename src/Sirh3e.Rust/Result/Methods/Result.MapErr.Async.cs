namespace Sirh3e.Rust.Result;

public readonly partial struct Result<TOk, TErr>
{
    public Task<Result<TOk, T>> MapErrAsync<T>(Func<TErr, Task<T>> map)
        => MatchAsync(ok => Result<TOk, T>.Ok(ok), async err => new Result<TOk, T>(await map(err)));
}