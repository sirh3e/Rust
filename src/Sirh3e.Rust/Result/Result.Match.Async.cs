using System;
using System.Threading.Tasks;
using static Sirh3e.Rust.Helper.ValueTask;

namespace Sirh3e.Rust.Result;

public readonly partial struct Result<TOk, TErr>
{
    public Task<T> MatchAsync<T>(Func<TOk, Task<T>> onOk, Func<TErr, Task<T>> onErr)
        => Match(onOk, onErr);

    public Task<T> MatchAsync<T>(Func<TOk, Task<T>> onOk, Func<TErr, ValueTask<T>> onErr)
        => Match(onOk, err => onErr(err).AsTask());

    public Task<T> MatchAsync<T>(Func<TOk, ValueTask<T>> onOk, Func<TErr, Task<T>> onErr)
        => Match(ok => onOk(ok).AsTask(), onErr);

    public ValueTask<T> MatchAsync<T>(Func<TOk, ValueTask<T>> onOk, Func<TErr, ValueTask<T>> onErr)
        => Match(onOk, onErr);

    public Task<T> MatchAsync<T>(Func<TOk, T> onOk, Func<TErr, Task<T>> onErr)
        => Match(ok => Task.FromResult(onOk(ok)), onErr);

    public ValueTask<T> MatchAsync<T>(Func<TOk, T> onOk, Func<TErr, ValueTask<T>> onErr)
        => Match(ok => ValueTaskFromResult(onOk(ok)), onErr);

    public Task<T> MatchAsync<T>(Func<TOk, Task<T>> onOk, Func<TErr, T> onErr)
        => Match(onOk, err => Task.FromResult(onErr(err)));

    public ValueTask<T> MatchAsync<T>(Func<TOk, ValueTask<T>> onOk, Func<TErr, T> onErr)
        => Match(onOk, err => ValueTaskFromResult(onErr(err)));

    public ValueTask<T> MatchAsync<T>(Func<TOk, T> onOk, Func<TErr, T> onErr)
        => ValueTaskFromResult(Match(onOk, onErr));
}