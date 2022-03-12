using System;
using System.Threading.Tasks;

namespace Sirh3e.Rust.Result;

public readonly partial struct Result<TOk, TErr>
{
    public async Task<T> MatchAsync<T>(Func<TOk, Task<T>> onOk, Func<TErr, Task<T>> onErr)
        => await Match(async ok => await onOk(ok), async err => await onErr(err));

    public async Task<T> MatchAsync<T>(Func<TOk, Task<T>> onOk, Func<TErr, ValueTask<T>> onErr)
        => await Match(async ok => await onOk(ok), async err => await onErr(err));

    public async Task<T> MatchAsync<T>(Func<TOk, ValueTask<T>> onOk, Func<TErr, Task<T>> onErr)
        => await Match(async ok => await onOk(ok), async err => await onErr(err));

    public async Task<T> MatchAsync<T>(Func<TOk, ValueTask<T>> onOk, Func<TErr, ValueTask<T>> onErr)
        => await Match(async ok => await onOk(ok), async err => await onErr(err));

    public async Task<T> MatchAsync<T>(Func<TOk, T> onOk, Func<TErr, Task<T>> onErr)
        => await Match(ok => Task.FromResult(onOk(ok)), async err => await onErr(err));

    public async Task<T> MatchAsync<T>(Func<TOk, T> onOk, Func<TErr, ValueTask<T>> onErr)
        => await Match(ok => Task.FromResult(onOk(ok)), async err => await onErr(err));

    public async Task<T> MatchAsync<T>(Func<TOk, Task<T>> onOk, Func<TErr, T> onErr)
        => await Match(async ok => await onOk(ok), err => Task.FromResult(onErr(err)));

    public async Task<T> MatchAsync<T>(Func<TOk, ValueTask<T>> onOk, Func<TErr, T> onErr)
        => await Match(async ok => await onOk(ok), err => Task.FromResult(onErr(err)));

    public Task<T> MatchAsync<T>(Func<TOk, T> onOk, Func<TErr, T> onErr)
        => Task.FromResult(Match(onOk, onErr));
}