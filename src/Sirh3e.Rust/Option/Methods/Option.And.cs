namespace Sirh3e.Rust.Option
{
    public readonly partial struct Option<TSome>
    {
        /// <summary>
        /// Returns None if the option is None, otherwise returns option.
        /// </summary>
        /// <param name="option"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public Option<T> And<T>(Option<T> option)
            => IsNone ? Option<T>.None : option;
    }
}