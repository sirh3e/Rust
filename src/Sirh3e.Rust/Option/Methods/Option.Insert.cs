namespace Sirh3e.Rust.Option
{
    public partial struct Option<TSome>
    {
        /// <summary>
        /// Inserts value into the option then returns a mutable reference to it.
        /// If the option already contains a value, the old value is dropped / disposed.
        /// </summary>
        /// <param name="some"></param>
        /// <returns>Returns the inserted value back</returns>
        /// <exception cref="ArgumentNullException">If the inserted value is null</exception>
        public TSome Insert(TSome some)
        {
            _ = some ?? throw new ArgumentNullException(nameof(some));

            if ( IsSome && _some is IDisposable disposable )
            {
                disposable.Dispose();
            }

            SetSome(some);

            return _some;
        }
    }
}