using System;

namespace Sirh3e.Rust.Option
{
    public partial struct Option<TSome>
    {
        /// <summary>
        /// Returns the contained Some value or a provided default.
        /// Arguments passed to unwrap_or are eagerly evaluated; if you are passing the result of a function call, it is recommended to use unwrap_or_else, which is lazily evaluated.
        /// </summary>
        /// <param name="default"></param>
        /// <returns></returns>
        public TSome UnwrapOr(TSome @default)
            => Match(
                some => some,
                () => @default ?? throw new ArgumentNullException(nameof(@default))
            );
    }
}