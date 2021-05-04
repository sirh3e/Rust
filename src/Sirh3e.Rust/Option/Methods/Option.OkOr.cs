using System;
using Sirh3e.Rust.Result;

namespace Sirh3e.Rust.Option
{
    public partial struct Option<TSome>
    {
        public Result<TSome, TErr> OkOr<TErr>(TErr err)
        {
            return Match(
                Result<TSome, TErr>.Ok,
                () =>
                {
                    if (err is null)
                        throw new ArgumentNullException(nameof(err));
                    return Result<TSome, TErr>.Err(err);
                });
        }
    }
}