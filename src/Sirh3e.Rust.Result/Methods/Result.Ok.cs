using Sirh3e.Rust.Option;

namespace Sirh3e.Rust.Result
{
    public readonly partial struct Result<TOk, TErr>
    {
        public Option<TOk> Ok()
            => IsOk switch
            {
                true => Option<TOk>.Some(_ok),
                false => Option<TOk>.None,
            };
    }
}