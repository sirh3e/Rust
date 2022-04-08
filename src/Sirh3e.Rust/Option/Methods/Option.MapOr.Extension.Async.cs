namespace Sirh3e.Rust.Option;

public static partial class Extension
{
    public static async Task<T> MapOrAsync<TSome, T>(this Task<Option<TSome>> task, T @default, Func<TSome, Task<T>> map)
        => await (await task.ConfigureAwait(false)).MapOrAsync(@default, map).ConfigureAwait(false);
}