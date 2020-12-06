using Sirh3e.Rust.Option;

namespace Sirh3e.Rust.Result
{
    public readonly partial struct Result<TOk, TErr>
    {
        public Option<TErr> Err()
            => IsErr switch
            {
                true => Option<TErr>.Some(_err),
                false => Option<TErr>.None,
            };
    }
}