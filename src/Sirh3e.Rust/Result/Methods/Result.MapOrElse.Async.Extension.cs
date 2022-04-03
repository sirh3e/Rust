namespace Sirh3e.Rust.Result;

public static partial class Extension
{
    public static async Task<T> MapOrElseAsync<TOk, TErr, T>(this Task<Result<TOk, TErr>> task, Func<TErr, Task<T>> @default, Func<TOk, Task<T>> map)
        => await (await task.ConfigureAwait(false)).MapOrElseAsync(@default, map).ConfigureAwait(false);
}