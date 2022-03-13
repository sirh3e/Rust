using System.Runtime.CompilerServices;
#if !NET2_0_OR_GREATER
using System.Reflection;
#endif

namespace Sirh3e.Rust;

internal static partial class Helper
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static bool IsSome<TSome>(TSome some)
        => IsValueType(some) || some != null;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsValueType<TValue>(TValue value)
#if NETSTANDARD2_0_OR_GREATER || NET5_0_OR_GREATER
        => typeof(TValue).IsValueType;
#else
        => typeof(TValue).GetTypeInfo().IsValueType;
#endif
}