namespace Sirh3e.Rust.Result
{
    public readonly partial struct Result<TOk, TErr>
    {
        /// <summary>
        /// Returns the contained Ok value or computes it from a closure.
        /// </summary>
        /// <param name="map"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Throws only if map is null</exception>
        public TOk UnwrapOrElse(Func<TErr, TOk> map)
            => IsOk ? _ok : (_ = map ?? throw new ArgumentNullException(nameof(map)))(_err);
    }
}