using Sirh3e.Rust.Option;

namespace Sirh3e.Rust.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Interface | AttributeTargets.Struct)]
public class ToDo : Attribute
{
    public readonly string Message;
    public readonly Option<ulong> Issue;

    public ToDo(string message) : this(message, Option<ulong>.None) { }

    public ToDo(string message, Option<ulong> issue)
    {
        Message = message ?? throw new ArgumentNullException(nameof(message));
        Issue = issue;
    }
}