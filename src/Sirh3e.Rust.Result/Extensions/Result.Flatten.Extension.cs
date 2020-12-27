namespace Sirh3e.Rust.Result.Extensions
{
    public static partial class ResultExtension
    {
        public static Result<TOk, TErr> Flatten<TOk, TErr>(this Result<Result<TOk, TErr>, TErr> result) => result.IsOk ?
                result.Unwrap() :
                Result<TOk, TErr>.Err(result.UnwrapErr());

        public static Result<TOk, TErr> Flatten<TOk, TErr>(this Result<TOk, TErr> result) => result;
    }
}