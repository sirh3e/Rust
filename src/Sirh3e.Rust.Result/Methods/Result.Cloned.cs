using System;

namespace Sirh3e.Rust.Result
{
    public readonly partial struct Result<TOk, TErr>
    {
        public Result<TOk, TErr> Cloned()
            => IsOk ? Ok(_ok) : Err(_err); //ToDo refactor this view: https://doc.rust-lang.org/std/result/enum.Result.html#impl-Clone
    }
}