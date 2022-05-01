namespace Sirh3e.Rust.Option
{
    public partial struct Option<TSome>
    {
        /// <summary>
        /// Returns None if the option is None, otherwise calls func with the wrapped value and returns the result.
        /// Some languages call this operation flatmap.
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public Option<TSome> AndThen(Func<TSome, Option<TSome>> func)
            => Match(func, () => None);
    }
}