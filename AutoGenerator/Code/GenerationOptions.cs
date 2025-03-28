using System.Reflection;

namespace AutoGenerator.Code;

public class GenerationOptions
{
    public string ClassName { get; set; }
    public Type SourceType { get; }
    public string NamespaceName { get; set; } = "GeneratedClasses";
    public string AdditionalCode { get; set; } = "";
    public List<Type> Interfaces { get; set; } = new List<Type>();

    public PropertyInfo[] Properties { get; set; } 

    public GenerationOptions(string className, Type sourceType)
    {
        ClassName = className;
        SourceType = sourceType;

        Properties=sourceType.GetProperties();

    }

    public List<string> Usings { get; set; } = new List<string>();
    public Type BaseClass { get; set; } = null;
    public string Template { get; set; } = @"
        public class {ClassName} {BaseClass} {Interfaces}
        {
            {Properties}
            {AdditionalCode}
        }
    ";
}
