using System;

namespace Sirh3e.Rust.Option
{
    public partial struct Option<TSome>
    {
        /// <summary>
        /// Maps an Option&lt;TSome&gt; to Option&lt;T&gt; by applying a function to a contained value.
        /// </summary>
        /// <param name="map"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public Option<T> Map<T>(Func<TSome, T> map)
            => Match(
                some => Option<T>.Some(map(some) ?? throw new ArgumentNullException(nameof(map))),
                () => Option<T>.None
            );
    }
}