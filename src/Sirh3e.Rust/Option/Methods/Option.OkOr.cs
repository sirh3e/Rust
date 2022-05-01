using Sirh3e.Rust.Result;

namespace Sirh3e.Rust.Option
{
    public partial struct Option<TSome>
    {
        public Result<TSome, TErr> OkOr<TErr>(TErr err)
            => Match(
                Result<TSome, TErr>.Ok,
                () => Result<TSome, TErr>.Err(err ?? throw new ArgumentNullException(nameof(err)))
                );
    }
}