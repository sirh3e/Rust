using System;

namespace Sirh3e.Rust.Option
{
    public readonly partial struct Option<TSome>
    {
        /// <summary>
        /// Applies a function to the contained value (if any), or returns the provided default (if not).
        /// </summary>
        /// <param name="default"></param>
        /// <param name="converter"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T MapOr<T>(T @default, Func<TSome, T> converter)
        {
            return Match(
                some => converter(some) ?? throw new ArgumentNullException(nameof(converter)),
                () => @default ?? throw new ArgumentNullException(nameof(@default))
            );
        }
    }
}