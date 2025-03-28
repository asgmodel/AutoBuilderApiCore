using AutoGenerator.Helper.Translation;
using System.Reflection;


namespace AutoGenerator.Code;

public class DtoGenerator : GenericClassGenerator, ITGenerator
{


     class TLG
    {
        public ITranslationData translationData { get; set; }
    }
    public new string Generate(GenerationOptions options)
    {

        options.ClassName += "Dto";

        var properties = options.Properties;
        var lsttemp=new List<PropertyInfo>();
        var pro = new TranslationData();


        foreach (var property in properties)
        {
            if (property.GetCustomAttributes<ToTranslationAttribute>().Any())
            {

                var newProperty = typeof(TLG).GetType().GetProperties().FirstOrDefault();
              
                lsttemp.Add(newProperty);
            }
            else
                lsttemp.Add(property);
        }

        options.Properties = lsttemp.ToArray();

        string generatedCode = base.Generate(options);



        return generatedCode;
    }

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
