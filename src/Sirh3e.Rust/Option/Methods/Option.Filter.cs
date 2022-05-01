namespace Sirh3e.Rust.Option
{
    public partial struct Option<TSome>
    {
        /// <summary>
        /// Returns None if the option is None, otherwise calls predicate with the wrapped value and returns:
        /// [Some(TSome)] if predicate returns true (where t is the wrapped value), and None if predicate returns false.
        /// This function works similar to Iterator::filter(). You can imagine the Option&lt;TSome&gt; being an iterator over one or zero elements. filter() lets you decide which elements to keep.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Throws only if predicate is null</exception>
        public Option<TSome> Filter(Func<TSome, bool> predicate)
        {
            if ( IsNone )
            {
                return None;
            }

            if ( predicate is null )
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            return predicate(_some) ? Some(_some) : None;
        }
    }
}