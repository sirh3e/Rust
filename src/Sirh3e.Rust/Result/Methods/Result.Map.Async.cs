namespace Sirh3e.Rust.Result;

public readonly partial struct Result<TOk, TErr>
{
    public Task<Result<T, TErr>> MapAsync<T>(Func<TOk, Task<T>> map)
        => MatchAsync(async ok => new Result<T, TErr>(await map(ok)), err => Result<T, TErr>.Err(err));
}