using System;

namespace Sirh3e.Rust.Result
{
    public readonly partial struct Result<TOk, TErr>
    {
        public Result<TOk, TErr> Flatten()
        {
            throw new NotImplementedException(); //ToDo find away
        }
    }
}