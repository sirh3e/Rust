namespace Sirh3e.Rust.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Interface | AttributeTargets.Struct, AllowMultiple = true)]
internal class ToDo : Attribute
{
    public readonly ulong Issue;
    public readonly string Message;

    public ToDo(ulong issue, string message)
    {
        Message = message ?? throw new ArgumentNullException(nameof(message));
        Issue = issue;
    }
}