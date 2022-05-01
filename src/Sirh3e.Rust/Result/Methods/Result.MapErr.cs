namespace Sirh3e.Rust.Result;

public readonly partial struct Result<TOk, TErr>
{
    /// <summary>
    /// Maps a Result<TOk, TErr> to Result<TOk, T> by applying a function to a contained Err value, leaving an Ok value untouched.
    /// This function can be used to pass through a successful result while handling an error.
    /// </summary>
    /// <param name="map"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">Throws only if map is null</exception>
    public Result<TOk, T> MapErr<T>(Func<TErr, T> map)
        => Match(
                 Result<TOk, T>.Ok,
                 err => Result<TOk, T>.Err((_ = map ?? throw new ArgumentNullException(nameof(map)))(err))
                );
}