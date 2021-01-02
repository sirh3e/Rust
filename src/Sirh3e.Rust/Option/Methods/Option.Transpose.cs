using System;
using Sirh3e.Rust.Result;

namespace Sirh3e.Rust.Option
{
    public readonly partial struct Option<TSome>
    {
        public Result<Option<TSome>, TErr> Transpose<TErr>()
        {
            throw new NotImplementedException();
        }
    }
}