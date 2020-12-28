using Sirh3e.Rust.Option;

namespace Sirh3e.Rust.Result.Extensions
{
    public static partial class ResultExtension
    {
        /// <summary>
        /// Transposes a Result of an Option into an Option of a Result.
        /// Ok(None) will be mapped to None. Ok(Some(_)) and Err(_) will be mapped to Some(Ok(_)) and Some(Err(_)). 
        /// </summary>
        /// <param name="result"></param>
        /// <typeparam name="TOk"></typeparam>
        /// <typeparam name="TErr"></typeparam>
        /// <returns></returns>
        public static Option<Result<TOk, TErr>> Transpose<TOk, TErr>(this Result<Option<TOk>, TErr> result)
        {
            if (result.IsErr)
            {
                return Option<Result<TOk, TErr>>.Some(Result<TOk, TErr>.Err(result.Err().Unwrap()));
            }

            var option = result.Ok().Unwrap();

            return option.IsNone ?
                Option<Result<TOk, TErr>>.None :
                Option<Result<TOk, TErr>>.Some(Result<TOk, TErr>.Ok(option.Unwrap()));
        }
    }
}