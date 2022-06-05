#nullable enable
namespace Sirh3e.Rust.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Interface | AttributeTargets.Struct)]
internal class Unstable : Attribute
{
    public readonly string Feature;
    public readonly ulong Issue;
    public readonly string? Reason;

    public Unstable(string feature, ulong issue)
    {
        Feature = feature ?? throw new ArgumentNullException(nameof(feature));
        Issue = issue;
    }

    public Unstable(string feature, ulong issue, string? reason) : this(feature, issue)
    {
        Reason = reason;
    }
}