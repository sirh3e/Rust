namespace Sirh3e.Rust.Option
{
    public readonly partial struct Option<TSome>
    {
        /// <summary>
        /// Consumes self while expecting None and returning nothing.
        /// </summary>
        public void UnwrapNone()
        {
            Match(
                some => ExpectNoneFailed("called `Option.UnwrapNone()` on a `Some` value", some),
                _ => { }
            );
        }
    }
}