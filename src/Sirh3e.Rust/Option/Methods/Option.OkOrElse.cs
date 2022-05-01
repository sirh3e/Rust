using Sirh3e.Rust.Result;

namespace Sirh3e.Rust.Option
{
    public partial struct Option<TSome>
    {
        public Result<TSome, TErr> OkOrElse<TErr>(Func<TErr> err)
            => Match(
                Result<TSome, TErr>.Ok,
                () => Result<TSome, TErr>.Err((_ = err ?? throw new ArgumentNullException(nameof(err)))())
                );
    }
}