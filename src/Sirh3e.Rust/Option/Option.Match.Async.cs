using System;
using System.Threading.Tasks;
using static Sirh3e.Rust.Helper.Task;
using static Sirh3e.Rust.Helper.ValueTask;

namespace Sirh3e.Rust.Option;

public partial struct Option<TSome>
{
    public Task MatchAsync(Action<TSome> onSome, Action onNone)
        => IsSome
            ? DoAsync(onSome, _some)
            : DoAsync(onNone);

    public Task MatchAsync(Func<TSome, Task> onSome, Action onNone)
        => IsSome
            ? onSome(_some)
            : DoAsync(onNone);

    public Task MatchAsync(Action<TSome> onSome, Func<Task> onNone)
        => IsSome
            ? DoAsync(onSome, _some)
            : onNone();

    public Task MatchAsync(Func<TSome, Task> onSome, Func<Task> onNone)
        => IsSome
            ? onSome(_some)
            : onNone();

    public Task<T> MatchAsync<T>(Func<TSome, T> onSome, Func<T> onNone)
        => Task.FromResult(IsSome ? onSome(_some) : onNone());

    public Task<T> MatchAsync<T>(Func<TSome, Task<T>> onSome, Func<T> onNone)
        => IsSome
            ? onSome(_some)
            : Task.FromResult(onNone());

    public Task<T> MatchAsync<T>(Func<TSome, T> onSome, Func<Task<T>> onNone)
        => IsSome
            ? Task.FromResult(onSome(_some))
            : onNone();

    public Task<T> MatchAsync<T>(Func<TSome, Task<T>> onSome, Func<Task<T>> onNone)
        => IsSome
            ? onSome(_some)
            : onNone();

    public async Task<T> MatchAsync<T>(Func<TSome, Task<T>> onSome, Func<ValueTask<T>> onNone)
        => IsSome
            ? await onSome(_some)
            : await onNone();

    public async Task<T> MatchAsync<T>(Func<TSome, ValueTask<T>> onSome, Func<Task<T>> onNone)
        => IsSome
            ? await onSome(_some)
            : await onNone();

    public ValueTask MatchAsync(Func<TSome, ValueTask> onSome, Action onNone)
        => IsSome
            ? onSome(_some)
            : DoValueAsync(onNone);

    public ValueTask MatchAsync(Action<TSome> onSome, Func<ValueTask> onNone)
        => IsSome
            ? DoValueAsync(onSome, _some)
            : onNone();

    public ValueTask MatchAsync(Func<TSome, ValueTask> onSome, Func<ValueTask> onNone)
        => IsSome
            ? onSome(_some)
            : onNone();

    public ValueTask<T> MatchAsync<T>(Func<TSome, ValueTask<T>> onSome, Func<T> onNone)
        => IsSome
            ? onSome(_some)
            : ValueTaskFromResult(onNone());

    public ValueTask<T> MatchAsync<T>(Func<TSome, T> onSome, Func<ValueTask<T>> onNone)
        => IsSome
            ? ValueTaskFromResult(onSome(_some))
            : onNone();

    public ValueTask<T> MatchAsync<T>(Func<TSome, ValueTask<T>> onSome, Func<ValueTask<T>> onNone)
        => IsSome
            ? onSome(_some)
            : onNone();
}