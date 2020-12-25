using Sirh3e.Rust.Option;

namespace Sirh3e.Rust.Result.Extensions
{
    public static partial class ResultExtension
    {
        public static Option<Result<TOk, TErr>> Transpose<TOk, TErr>(this Result<Option<TOk>, TErr> result)
        {
            if (!result.IsOk)
                return Option<Result<TOk, TErr>>.Some(Result<TOk, TErr>.Err(result.Err().Unwrap()));

            var option = result.Ok().Unwrap();

            return option.IsNone ? Option<Result<TOk, TErr>>.None : Option<Result<TOk, TErr>>.Some(Result<TOk, TErr>.Ok(option.Unwrap()));
        }
    }
}