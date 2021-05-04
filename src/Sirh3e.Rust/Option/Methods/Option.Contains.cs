namespace Sirh3e.Rust.Option
{
    public partial struct Option<TSome>
    {
        /// <summary>
        /// Returns true if the option is a Some value containing the given value.
        /// </summary>
        /// <param name="some"></param>
        /// <returns></returns>
        public bool Contains(TSome some)
            => Match(s => s.Equals(some), () => false);
    }
}