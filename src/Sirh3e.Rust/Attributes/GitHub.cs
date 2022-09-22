namespace Sirh3e.Rust.Attributes;

[AttributeUsage(Utilities.AttributeTargets)]
internal class GitHub : Attribute
{
    public readonly ulong Issue;
    public readonly string Url;

    public GitHub(ulong issue, string url)
    {
        Issue = issue;
        Url = url ?? throw new ArgumentNullException(nameof(url));
    }
}