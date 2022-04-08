namespace Sirh3e.Rust.Result;

public static partial class Extension
{
    public static async Task<T> MapOrAsync<TOk, TErr, T>(this Task<Result<TOk, TErr>> task, T @default, Func<TOk, Task<T>> map)
        => await (await task.ConfigureAwait(false)).MapOrAsync(@default, map).ConfigureAwait(false);
}