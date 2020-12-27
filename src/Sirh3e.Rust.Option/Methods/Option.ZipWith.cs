using System;

namespace Sirh3e.Rust.Option
{
    public readonly partial struct Option<TSome>
    {
        public Option<TR> ZipWith<TU, TR>(Option<TU> option, Func<TSome, TU, TR> func)
        {
            return (IsSome, option.IsSome) switch
            {
                (true, true) => Option<TR>.Some(func(_some, option._some) ??
                                                throw new ArgumentNullException(nameof(func))),
                _ => Option<TR>.None
            };
        }
    }
}