namespace Sirh3e.Rust.Option
{
    public readonly partial struct Option<TSome>
    {
        /// <summary>
        /// Returns the contained Some value, consuming the self value.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public TSome Expect(string message)
            => Match(s => s, () => ExpectFailed(message));
    }
}