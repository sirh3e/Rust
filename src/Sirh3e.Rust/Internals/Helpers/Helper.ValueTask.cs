using STT = System.Threading.Tasks;
namespace Sirh3e.Rust.Internals.Helpers;

internal static partial class Helper
{
    internal static class ValueTask
    {
        [ToDo("Find a better name")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static STT.ValueTask DoValueAsync(Action action)
        {
            action();
            return GetCompletedValueTask();
        }

        [ToDo("Find a better name")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static STT.ValueTask DoValueAsync<T>(Action<T> action, T value)
        {
            action(value);
            return GetCompletedValueTask();
        }

        [Docs("https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask?view=net-6.0#remarks")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static STT.ValueTask GetCompletedValueTask()
#if NET5_0_OR_GREATER 
            => STT.ValueTask.CompletedTask;
#else
            => default;
#endif

        [Docs("https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask?view=net-6.0#remarks")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static STT.ValueTask<T> ValueTaskFromResult<T>(T value)
#if NET5_0_OR_GREATER 
            => STT.ValueTask.FromResult(value);
#else
            => new(value);
#endif
    }
}