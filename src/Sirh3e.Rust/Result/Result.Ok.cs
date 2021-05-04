using System;

namespace Sirh3e.Rust.Result
{
    public readonly ref struct Ok<TOk>
    {
        private readonly TOk _ok;

        public Ok(TOk ok)
        {
            _ok = ok ?? throw new ArgumentNullException(nameof(ok));
        }
    }
}