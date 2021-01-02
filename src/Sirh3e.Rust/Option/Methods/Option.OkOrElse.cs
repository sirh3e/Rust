using System;
using Sirh3e.Rust.Result;

namespace Sirh3e.Rust.Option
{
    public readonly partial struct Option<TSome>
    {
        public Result<TSome, TErr> OkOrElse<TErr>(Func<TErr> err)
        {
            return Match(
                Result<TSome, TErr>.Ok,
                () =>
                {
                    if (err is null)
                        throw new ArgumentNullException(nameof(err));
                    return Result<TSome, TErr>.Err(err());
                });
        }
    }
}