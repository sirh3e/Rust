using System.Runtime.CompilerServices;

namespace Sirh3e.Rust.Result
{
    public static class Extension
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Err<TErr> Err<TErr>(TErr err) => new(err);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Ok<TOk> Ok<TOk>(TOk ok) => new(ok);
    }
}