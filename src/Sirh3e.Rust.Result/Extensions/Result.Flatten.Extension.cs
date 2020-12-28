namespace Sirh3e.Rust.Result.Extensions
{
    public static partial class ResultExtension
    {
        /// <summary>
        /// Converts from Result&lt;Result&lt;TOk, TErr&gt;, TErr&gt; to Result&lt;TOk, TErr&gt;
        /// </summary>
        /// <param name="result"></param>
        /// <typeparam name="TOk"></typeparam>
        /// <typeparam name="TErr"></typeparam>
        /// <returns></returns>
        public static Result<TOk, TErr> Flatten<TOk, TErr>(this Result<Result<TOk, TErr>, TErr> result)
            => result.IsOk ?
                result.Unwrap() :
                Result<TOk, TErr>.Err(result.UnwrapErr());

        /// <summary>
        /// Converts from Result&lt;Result&lt;TOk, TErr&gt;, TErr&gt; to Result&lt;TOk, TErr&gt;
        /// </summary>
        /// <param name="result"></param>
        /// <typeparam name="TOk"></typeparam>
        /// <typeparam name="TErr"></typeparam>
        /// <returns></returns>
        public static Result<TOk, TErr> Flatten<TOk, TErr>(this Result<TOk, TErr> result) => result;
    }
}