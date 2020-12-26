using Sirh3e.Rust.Option;

namespace Sirh3e.Rust.Result
{
    public readonly partial struct Result<TOk, TErr>
    {
        /// <summary>
        /// Converts from Result&lt;TOk, TErr&gt; to Option&lt;TErr&gt;.
        /// Converts self into an Option&lt;TErr&gt;, consuming self, and discarding the success value, if any.
        /// </summary>
        /// <returns></returns>
        public Option<TErr> Err()
            => IsErr switch
            {
                true => Option<TErr>.Some(_err),
                false => Option<TErr>.None
            };
    }
}