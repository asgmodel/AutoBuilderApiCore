using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace AutoGenerator.Code;

public class GenericClassGenerator : ITGenerator
{
    private string generatedCode; //
    public event EventHandler<string>? OnCodeGenerated;
    public event EventHandler<string>? OnCodeSaved;
    public string Generate(GenerationOptions options)
    {
        var properties = options.Properties;
        var propertyDeclarations = new List<string>();

        foreach (var prop in properties)
        {
            propertyDeclarations.Add($@"
                public {CodeGeneratorUtils.GetPropertyTypeName(prop.PropertyType)}{(prop.PropertyType.IsNullableType() ? "" : "")} {prop.Name} {{ get; set; }}
            ");
        }

        var baseClass = options.BaseClass != null ? $": {options.BaseClass}" : "";
        if (options.BaseClass != null && options.Interfaces.Any())
        {
            baseClass += ", ";
        }
        else if (options.BaseClass == null && options.Interfaces.Any())
        {
            baseClass = ": ";
        }
        var interfaces = options.Interfaces.Any() ? $" {string.Join(", ", options.Interfaces.Select(i => i.Name))}" : "";

        var replacements = new Dictionary<string, string>
        {
            { "ClassName", options.ClassName },
            { "Properties", string.Join("//", propertyDeclarations) },
            { "AdditionalCode", options.AdditionalCode },
            { "Interfaces", interfaces },
            { "BaseClass", baseClass }
        };

        generatedCode = CodeGeneratorUtils.ApplyTemplate(options.Template, replacements);

        var namespaceDeclaration = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName(options.NamespaceName))
            .AddMembers(SyntaxFactory.ParseMemberDeclaration(generatedCode));

        options.Usings.Add("System");
        List<UsingDirectiveSyntax> usingDirectives = new List<UsingDirectiveSyntax>();

        foreach (var ns in options.Usings)
        {

            usingDirectives.Add(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(ns)));
        }

        var compilationUnit = SyntaxFactory.CompilationUnit()
            .AddUsings(usingDirectives.ToArray())
            .AddMembers(namespaceDeclaration)
            .NormalizeWhitespace();

        generatedCode = compilationUnit.ToFullString(); //  ÕœÌÀ «·ﬂÊœ «·„ Ê·œ

        return generatedCode;
    }



    public void SaveToFile(string filePath)
    {
        if (!string.IsNullOrEmpty(generatedCode))
        {
            File.WriteAllText(filePath, generatedCode);
            Console.WriteLine($"Generated code saved to {filePath}");
        }
        else
        {
            Console.WriteLine("No generated code to save.");
        }
    }
}
