using AutoGenerator.ApiFolder;
using AutoGenerator.Helper.Translation;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Options;
using System.Reflection;
using System.Text;


namespace AutoGenerator.Code;

public class DtoGenerator : GenericClassGenerator, ITGenerator
{


   


    public static string getPTrns(string name)
    {
        return  $@"
            public ITranslationData? {name} {{ get; set; }}";
    }

   
    public new string Generate(GenerationOptions options)
    {

        

        var properties = options.Properties;
        var lsttemp=new List<PropertyInfo>();

       


        foreach (var property in properties)
        {
            if (property.GetCustomAttributes<ToTranslationAttribute>().Any())
            {

              
                options.AdditionalCode += getPTrns(property.Name);
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

    
    public   void GenrateandSave(GenerationOptions options,string path)
    {

        Generate(options);
        SaveToFile(options.ClassName);
    }


     

    public static void GenerateBuild(string type,string subtype,string NamespaceName,string pathfile)
    {


        var assembly = Assembly.GetExecutingAssembly();


        var models = assembly.GetTypes().Where(t => typeof(ITModel).IsAssignableFrom(t) && t.IsClass).ToList();

        


        foreach (var model in models)
        {
            var options = new GenerationOptions($"{model.Name}{NamespaceName}{subtype}{type}", model)
            {
                NamespaceName = $"{type}.{subtype}.{NamespaceName}",
                AdditionalCode = @"",
                Interfaces = new List<Type> {subtype=="Build"?typeof(ITBuildDto): typeof(ITShareDto) },
                Usings = new List<string> { "Microsoft.CodeAnalysis", "AutoGenerator" }
            };


           options.AdditionalCode+= GenerateDtoProperties( options.Properties, models, $"{NamespaceName}{subtype}{type}");
            options.Properties =new List<PropertyInfo>().ToArray();
            ITGenerator generator = new DtoGenerator();
            generator.Generate(options);
         
            string jsonFile = Path.Combine(pathfile, $"{subtype}/{NamespaceName}/{options.ClassName}.cs");
            generator.SaveToFile(jsonFile);

            Console.WriteLine($"✅ {options.ClassName} has been created successfully!");
        }

        
        //if (root == null)
        //{
        //    root = new FolderNode("DyModels");
        //    ApiFolderGenerator.ROOT.Children.Add(root);
        


        

        //var generator = new DtoGenerator();
        //string reqDtofile= Path.Combine(projectPath, $"{options.ClassName}.cs");

        //generator.GenrateandSave(options, );

    }



    public static string GenerateDtoProperties(PropertyInfo[] properties,List<Type?> models,string  end)
    {
        var propertyDeclarations = new StringBuilder();

        foreach (var prop in properties)
        {
             
           if(models.Contains(prop.PropertyType))
            {
                propertyDeclarations.AppendLine($@"
                public {prop.PropertyType.Name}{end}? {prop.Name} {{ get; set; }} ");
            }

            if (prop.GetCustomAttributes<ToTranslationAttribute>().Any())
            {


                propertyDeclarations.AppendLine(getPTrns(prop.Name));
            }
            else
            {
                //propertyDeclarations.AppendLine($@"
                //public {prop.PropertyType.Name}? {prop.Name} {{ get; set; }} ");


                propertyDeclarations.AppendLine($@"
                    /// <summary>
                    /// {prop.Name} property for DTO.
                    /// </summary>
                    public {CodeGeneratorUtils.GetPropertyTypeName(prop.PropertyType)}{(prop.PropertyType.IsNullableType() ? "?" : "")} {prop.Name} {{ get; set; }}
                ");

            }
        }

        return propertyDeclarations.ToString();
    }


}

public class TypeInspector
{
    public static string GenerateDtoPropertyCode(string propertyName, Type propertyType)
    {
        StringBuilder sb = new StringBuilder();

        // فحص النوع وإعادة الكود المناسب بناءً على النوع
        if (propertyType == typeof(string))
        {
            sb.AppendLine($"        public string {propertyName} {{ get; set; }}");
        }
        else if (propertyType == typeof(int))
        {
            sb.AppendLine($"        public int {propertyName} {{ get; set; }}");
        }
        else if (propertyType == typeof(DateTime))
        {
            sb.AppendLine($"        public DateTime {propertyName} {{ get; set; }}");
        }
        else if (propertyType == typeof(DateTime?))
        {
            sb.AppendLine($"        public Nullable<DateTime> {propertyName} {{ get; set; }}");
        }
        else if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
        {
            // فحص الأنواع القابلة لأن تكون null مثل Nullable<int>
            sb.AppendLine($"        public {propertyType.GetGenericArguments()[0].Name}? {propertyName} {{ get; set; }}");
        }
        else if (propertyType.IsArray)
        {
            sb.AppendLine($"        public {propertyType.GetElementType()?.Name}[] {propertyName} {{ get; set; }}");
        }
        else if (typeof(System.Collections.IEnumerable).IsAssignableFrom(propertyType))
        {
            sb.AppendLine($"        public ICollection<{propertyType.Name}> {propertyName} {{ get; set; }}");
        }
        else
        {
            sb.AppendLine($"        public {propertyType.Name} {propertyName} {{ get; set; }}");
        }

        return sb.ToString();
    }
}