namespace System.Threading.Tasks;

#if NET45 || NETSTANDARD 
internal static class ValueTask
{
    internal static ValueTask<T> FromResult<T>(T value) => new(value);
}
#endif