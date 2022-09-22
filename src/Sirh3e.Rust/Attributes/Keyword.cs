namespace Sirh3e.Rust.Attributes;

[AttributeUsage(Utilities.AttributeTargets)]
public class Keyword : Attribute
{
    public readonly string Name;

    public Keyword(string name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }
}