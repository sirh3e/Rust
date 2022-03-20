using System;
using System.Threading.Tasks;
using static Sirh3e.Rust.Helper.Task;
using static Sirh3e.Rust.Helper.ValueTask;

namespace Sirh3e.Rust.Option;

public partial struct Option<TSome>
{
    public Task MatchAsync(Action<TSome> onSome, Action onNone)
    {
        Match(onSome, onNone);
        return GetCompletedTask();
    }

    public Task MatchAsync(Func<TSome, Task> onSome, Action onNone)
        => Match(onSome, () => DoAsync(onNone));

    public Task MatchAsync(Action<TSome> onSome, Func<Task> onNone)
        => Match(some => DoAsync(onSome, some), onNone);

    public Task MatchAsync(Func<TSome, Task> onSome, Func<Task> onNone)
        => Match(onSome, onNone);

    public Task<T> MatchAsync<T>(Func<TSome, T> onSome, Func<T> onNone)
        => Task.FromResult(Match(onSome, onNone));

    public Task<T> MatchAsync<T>(Func<TSome, Task<T>> onSome, Func<T> onNone)
        => Match(onSome, () => Task.FromResult(onNone()));

    public Task<T> MatchAsync<T>(Func<TSome, T> onSome, Func<Task<T>> onNone)
        => Match(some => Task.FromResult(onSome(some)), onNone);

    public Task<T> MatchAsync<T>(Func<TSome, Task<T>> onSome, Func<Task<T>> onNone)
        => Match(onSome, onNone);

    public Task<T> MatchAsync<T>(Func<TSome, Task<T>> onSome, Func<ValueTask<T>> onNone)
        => Match(onSome, () => onNone().AsTask());

    public Task<T> MatchAsync<T>(Func<TSome, ValueTask<T>> onSome, Func<Task<T>> onNone)
        => Match(some => onSome(some).AsTask(), onNone);

    public ValueTask MatchAsync(Func<TSome, ValueTask> onSome, Action onNone)
        => Match(onSome, () => DoValueAsync(onNone));

    public ValueTask MatchAsync(Action<TSome> onSome, Func<ValueTask> onNone)
        => Match(some => DoValueAsync(onSome, some), onNone);

    public ValueTask MatchAsync(Func<TSome, ValueTask> onSome, Func<ValueTask> onNone)
        => Match(onSome, onNone);

    public ValueTask<T> MatchAsync<T>(Func<TSome, ValueTask<T>> onSome, Func<T> onNone)
        => Match(onSome, () => ValueTaskFromResult(onNone()));

    public ValueTask<T> MatchAsync<T>(Func<TSome, T> onSome, Func<ValueTask<T>> onNone)
        => Match(some => ValueTaskFromResult(onSome(some)), onNone);

    public ValueTask<T> MatchAsync<T>(Func<TSome, ValueTask<T>> onSome, Func<ValueTask<T>> onNone)
        => Match(onSome, onNone);
}