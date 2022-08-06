using STT = System.Threading.Tasks;
namespace Sirh3e.Rust.Internals.Helpers;

internal static partial class Helper
{
    internal static class Task
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static STT.Task DoAsync(Action action)
        {
            action();
            return GetCompletedTask();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static STT.Task DoAsync<T>(Action<T> action, T value)
        {
            action(value);
            return GetCompletedTask();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static STT.Task GetCompletedTask()
#if NETSTANDARD1_3_OR_GREATER || NETCOREAPP1_0_OR_GREATER
            => STT.Task.CompletedTask;
#else
            => STT.Task.FromResult(0);
#endif
    }
}