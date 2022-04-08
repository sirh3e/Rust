namespace Sirh3e.Rust.Option;

public static partial class Extension
{
    public static async Task<Option<T>> MapAsync<TSome, T>(this Task<Option<TSome>> task, Func<TSome, Task<T>> map)
        => await (await task.ConfigureAwait(false)).MapAsync(map).ConfigureAwait(false);
}