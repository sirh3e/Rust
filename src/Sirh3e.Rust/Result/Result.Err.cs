using System;

namespace Sirh3e.Rust.Result
{
    public readonly ref struct Err<TErr>
    {
        internal readonly TErr Value;

        public Err(TErr ok)
        {
            Value = ok ?? throw new ArgumentNullException(nameof(ok));
        }
    }
}