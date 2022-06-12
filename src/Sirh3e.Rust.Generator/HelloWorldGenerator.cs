using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Sirh3e.Rust.Generator;

[Generator]
public class HelloWorldGenerator : ISourceGenerator
{

    public void Initialize(GeneratorInitializationContext context)
    {
    }
    
    public void Execute(GeneratorExecutionContext         context)
    {
        var sourceCodeBuilder = new StringBuilder();

        var text = @"using System;
namespace Sirh3e.Rust.Generated;

public static class HelloWorld
{
    public static void Main()
    {
        Console.WriteLine(""Hello, World!"");
    }
}";
        sourceCodeBuilder.Append(text);
        var sourceCode = sourceCodeBuilder.ToString();
        context.AddSource("Generated.cs", SourceText.From(sourceCode, Encoding.UTF8));
    }
}