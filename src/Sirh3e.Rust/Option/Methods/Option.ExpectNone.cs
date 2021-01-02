namespace Sirh3e.Rust.Option
{
    public readonly partial struct Option<TSome>
    {
        /// <summary>
        /// Consumes self while expecting None and returning nothing.
        /// </summary>
        /// <param name="message"></param>
        public void ExpectNone(string message)
            => Match(_ => { }, some => ExpectNoneFailed(message, some));
    }
}