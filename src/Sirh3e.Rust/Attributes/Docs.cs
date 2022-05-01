namespace Sirh3e.Rust.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Interface | AttributeTargets.Struct)]
public class Docs : Attribute
{
    public readonly string Url;

    public Docs(string url)
    {
        Url = url ?? throw new ArgumentNullException(nameof(url));
    }
}