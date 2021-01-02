namespace Sirh3e.Rust.Option
{
    public readonly partial struct Option<TSome>
    {
        /// <summary>
        /// Returns the option if it contains a value, otherwise returns option.
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        public Option<TSome> Or(Option<TSome> option)
        {
            return Match(Some, () => option);
        }
    }
}