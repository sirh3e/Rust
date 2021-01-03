namespace Sirh3e.Rust.Option
{
    public readonly partial struct Option<TSome>
    {
        /// <summary>
        /// Consumes self while expecting None and returning nothing.
        /// </summary>
        /// <param name="message"></param>
        public void ExpectNone(string message)
            => Match(some => ExpectNoneFailed(message, some), _ => { });
    }
}