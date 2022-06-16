using Microsoft.CodeAnalysis.CSharp;

namespace Sirh3e.Rust.Generator;

[Generator]
public class ResultGenerator : ISourceGenerator
{

    public void Initialize(GeneratorInitializationContext context)
    {
        context.RegisterForSyntaxNotifications(() => new ResultSyntaxReceiver());
        context.RegisterForPostInitialization(generator =>
        {
            //Have a look at Sirh3e.Rust.Generator.Attributes.ResultAttribute
            var sourceCode = @"
using System;

namespace Sirh3e.Rust.Generator.Attributes;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public sealed class ResultAttribute<TOk, TErr> : System.Attribute
{
}
";
            generator.AddSource("Sirh3e.Rust.Generator.Attribute.ResultAttribute.Generated.cs", SourceText.From(sourceCode, Encoding.UTF8));
        });
    }

    public void Execute(GeneratorExecutionContext context)
    {
        if ( context.SyntaxContextReceiver is not ResultSyntaxReceiver syntaxReceiver ) return;

        var classes = syntaxReceiver.ClassDeclarationSyntaxes;
        if ( classes.Any() is false ) return;

        foreach ( var @class in classes )
        foreach ( var attribute in @class.AttributeLists.SelectMany(a => a.Attributes) )
        {
            if ( attribute.Name is not GenericNameSyntax genericNameSyntax )
                continue;

            var typeArguments = genericNameSyntax.TypeArgumentList.Arguments;
            if ( typeArguments.Count != 2 ) continue; //ToDo add error message

            var okType  = typeArguments[0];
            var errType = typeArguments[1];
            
            var okFullString  = ToFullString(okType);
            var errFullString = ToFullString(errType);

            var resultFullString = $"Sirh3e.Rust.Result.Result<{okFullString},{errFullString}>";

            var builder = new StringBuilder();

            builder.AppendLine($"using System;")
                   .AppendLine($"namespace Sirh3e.Rust.Generated;")
                   .AppendLine($"public static partial class Results")
                   .AppendLine($"{{")
                   .AppendLine($"   public static partial class MathResult")
                   .AppendLine($"   {{")
                   .AppendLine($"       public static {resultFullString} Ok({okFullString} ok) => {resultFullString}.Ok(ok);")
                   .AppendLine($"       public static {resultFullString} Err({errFullString} err) => {resultFullString}.Err(err);")
                   .AppendLine($"   }}")
                   .AppendLine($"}}")
                ;
            
            context.AddSource("Sirh3e.Rust.Generator.Result.Generated.cs", SourceText.From(builder.ToString(), Encoding.UTF8));
            break;
        }
    }
    
    private static string ToFullString(TypeSyntax typeSyntax)
        => typeSyntax switch
        {
            PredefinedTypeSyntax predefinedTypeSyntax => predefinedTypeSyntax.ToFullString(),
            GenericNameSyntax genericNameSyntax => genericNameSyntax.ToFullString(),
            _ => throw new ArgumentOutOfRangeException(nameof(typeSyntax), typeSyntax, "Only predefined types are supported")
        };

    private class ResultSyntaxReceiver : ISyntaxContextReceiver
    {
        public List<ClassDeclarationSyntax> ClassDeclarationSyntaxes { get; } = new();

        public void OnVisitSyntaxNode(GeneratorSyntaxContext syntaxContext)
        {
            /*
#if DEBUG
            if ( Debugger.IsAttached is false )
            {
                Debugger.Launch();
            }
#endif
*/
            if ( syntaxContext.Node is not ClassDeclarationSyntax classDeclarationSyntax || !classDeclarationSyntax.AttributeLists.Any() )
                return;

            var modifiers = classDeclarationSyntax.Modifiers;
            foreach ( var modifier in modifiers )
            {
            }

            foreach ( var attributeSyntax in classDeclarationSyntax.AttributeLists.SelectMany(attributeListSyntax => attributeListSyntax.Attributes) )
            {
                if ( syntaxContext.SemanticModel.GetSymbolInfo(attributeSyntax).Symbol is not IMethodSymbol attributeSymbol ) continue;

                var attributeSymbolContainingTypeSymbol = attributeSymbol.ContainingType;
                var fullname                            = attributeSymbolContainingTypeSymbol.ToDisplayString();

                if ( (fullname.StartsWith("Sirh3e.Rust.Generator.Attributes.ResultAttribute") && fullname.EndsWith(">")) is false ) continue;

                ClassDeclarationSyntaxes.Add(classDeclarationSyntax);
            }
        }
    }
}