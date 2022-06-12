namespace Sirh3e.Rust.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Interface | AttributeTargets.Struct)]
public class Keyword : Attribute
{
    public readonly string Name;

    public Keyword(string name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }
}