namespace Sirh3e.Rust.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Interface | AttributeTargets.Struct)]
internal class ToDo : Attribute
{
    public readonly Option<ulong> Issue;
    public readonly string        Message;

    public ToDo(string message) : this(message, Option<ulong>.None) { }

    public ToDo(string message, Option<ulong> issue)
    {
        Message = message ?? throw new ArgumentNullException(nameof(message));
        Issue   = issue;
    }
}