namespace Sirh3e.Rust.Option
{
    public readonly partial struct Option<TSome>
    {
        /// <summary>
        /// Returns true if the option is a Some value containing the given value.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public TSome Expect(string message)
            => Match(s => s, () => ExpectFailed(message));
    }
}