using static Sirh3e.Rust.Helper.Task;

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
}