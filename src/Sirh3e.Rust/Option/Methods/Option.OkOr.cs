using System;
using Sirh3e.Rust.Result;

namespace Sirh3e.Rust.Option
{
    public readonly partial struct Option<TSome>
    {
        public Result<TSome, TErr> OkOr<TErr>(TErr err)
        {
            throw new NotImplementedException(nameof(err));
        }
    }
}