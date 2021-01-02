using System;

namespace Sirh3e.Rust.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Interface | AttributeTargets.Struct)]
    public class Stable : Attribute
    {
        public readonly string Feature;
        public readonly string Since;

        public Stable(string feature, string since)
        {
            Feature = feature ?? throw new ArgumentNullException(nameof(feature));
            Since = since ?? throw new ArgumentNullException(nameof(since));
        }
    }
}