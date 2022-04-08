namespace Sirh3e.Rust.Result;

public static partial class Extension
{
    public static async Task<Result<T, TErr>> MapAsync<TOk, TErr, T>(this Task<Result<TOk, TErr>> task, Func<TOk, Task<T>> map)
        => await (await task.ConfigureAwait(false)).MapAsync(map).ConfigureAwait(false);
}