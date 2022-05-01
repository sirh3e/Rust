namespace Sirh3e.Rust.Result
{
    public readonly partial struct Result<TOk, TErr>
    {
        /// <summary>
        /// Converts from Result&lt;TOk, TErr&gt; to Option&lt;TOk&gt;.
        /// Converts self into an Option&lt;TOk&gt;, consuming self, and discarding the error, if any.
        /// </summary>
        /// <returns></returns>
        public Option<TOk> Ok()
            => IsOk switch
            {
                true => Option<TOk>.Some(_ok),
                false => Option<TOk>.None
            };
    }
}