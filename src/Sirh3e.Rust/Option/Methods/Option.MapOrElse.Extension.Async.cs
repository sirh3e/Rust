namespace Sirh3e.Rust.Option;

public static partial class Extension
{
    public static async Task<T> MapOrElseAsync<TSome, T>(this Task<Option<TSome>> task, Func<Task<T>> @default, Func<TSome, Task<T>> converter)
        => await (await task.ConfigureAwait(false)).MapOrElse(@default, converter).ConfigureAwait(false);
}