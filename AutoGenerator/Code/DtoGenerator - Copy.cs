using System.Reflection;


namespace AutoGenerator.Code;

public class DsoGenerator : GenericClassGenerator, ITGenerator
{


    public new string Generate(GenerationOptions options)
    {


        string generatedCode = base.Generate(options);



        return generatedCode;
    }

    // تجاوز دالة SaveToFile لتخصيص حفظ الملف
    public new void SaveToFile(string filePath)
    {
   
        base.SaveToFile(filePath);
    }

    public List<string> GenerateDtoProperties(PropertyInfo[] properties)
    {
        var propertyDeclarations = new List<string>();

        foreach (var prop in properties)
        {
            propertyDeclarations.Add($@"
                /// <summary>
                /// {prop.Name} property for DTO.
                /// </summary>
                public {CodeGeneratorUtils.GetPropertyTypeName(prop.PropertyType)}{(prop.PropertyType.IsNullableType() ? "?" : "")} {prop.Name} {{ get; set; }}
            ");
        }

        return propertyDeclarations;
    }
}
