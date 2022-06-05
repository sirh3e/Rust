namespace Sirh3e.Rust.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Interface | AttributeTargets.Struct)]
internal class Source : Attribute
{
    public readonly string Url;

    public Source(string url)
    {
        Url = url ?? throw new ArgumentNullException(nameof(url));
    }
}