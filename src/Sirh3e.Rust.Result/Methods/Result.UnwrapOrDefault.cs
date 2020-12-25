using System;

namespace Sirh3e.Rust.Result
{
    public readonly partial struct Result<TOk, TErr>
    {
        public TOk UnwrapOrDefault() => IsOk ? _ok : Activator.CreateInstance<TOk>();
    }
}