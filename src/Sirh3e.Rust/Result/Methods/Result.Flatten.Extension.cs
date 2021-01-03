namespace Sirh3e.Rust.Result
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
        {
            return result.Match(
                ok => Result<TOk, TErr>.Ok(ok.Unwrap()),
                Result<TOk, TErr>.Err);
        }

        /// <summary>
        /// Converts from Result&lt;Result&lt;TOk, TErr&gt;, TErr&gt; to Result&lt;TOk, TErr&gt;
        /// </summary>
        /// <param name="result"></param>
        /// <typeparam name="TOk"></typeparam>
        /// <typeparam name="TErr"></typeparam>
        /// <returns></returns>
        public static Result<TOk, TErr> Flatten<TOk, TErr>(this Result<TOk, TErr> result)
        {
            return result;
        }
    }
}