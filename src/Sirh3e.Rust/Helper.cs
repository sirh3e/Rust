using System.Runtime.CompilerServices;
#if !NET2_0_OR_GREATER
using System.Reflection;
#endif

namespace Sirh3e.Rust
{
    internal static class Helper
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsSome<TSome>(TSome some)
            => IsValueType(some) || some != null;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsValueType<TValue>(TValue value)
#if NET2_0_OR_GREATER
            => typeof(TSome).IsValueType;
#else
            => typeof(TValue).GetTypeInfo().IsValueType;
#endif
    }
}