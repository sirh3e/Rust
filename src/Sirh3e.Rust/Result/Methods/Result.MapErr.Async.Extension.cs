namespace Sirh3e.Rust.Result;

public static partial class Extension
{
    public static async Task<Result<TOk, T>> MapErrAsync<TOk, TErr, T>(this Task<Result<TOk, TErr>> task, Func<TErr, Task<T>> map)
        => await (await task.ConfigureAwait(false)).MapErrAsync(map).ConfigureAwait(false);
}