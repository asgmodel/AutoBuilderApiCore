using AutoGenerator.ApiFolder;
using AutoGenerator.Helper.Translation;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Options;
using System.Reflection;
using System.Text;


namespace AutoGenerator.Code;

public class ServiceGenerator : GenericClassGenerator, ITGenerator
{

    public new string Generate(GenerationOptions options)
    {

        string generatedCode = base.Generate(options);



        return generatedCode;
    }

    public new void SaveToFile(string filePath)
    {


        base.SaveToFile(filePath);
    }


    public static void GenerateAll(string type, string subtype, string NamespaceName, string pathfile)
    {


        var assembly = Assembly.GetExecutingAssembly();


        var models = assembly.GetTypes().Where(t => typeof(ITModel).IsAssignableFrom(t) && t.IsClass).ToList();

        





        NamespaceName = $"Services.{subtype}";

        foreach (var model in models)
        {
            var options = new GenerationOptions($"{model.Name}{type}", model)
            {
                NamespaceName= NamespaceName,
                Template = GetTemplateService(null, NamespaceName, model.Name)
                            ,
                Usings = new List<string>
                        {
                            "AutoGenerator.Data",
                            "AutoMapper",
                         
                            "Microsoft.Extensions.Logging",
                            "System.Collections.Generic",

                            "AutoGenerator.Services.Base",
                            "Dso.Request",
                            "Dso.Response",
                            "AutoGenerator.Models",
                             "Dto.Share.Request",
                            "Dto.Share.Response",


                            "Repositorys.Share",
                          

                        }


            };

           

           




            ITGenerator generator = new ServiceGenerator();
            generator.Generate(options);

            string jsonFile = Path.Combine(pathfile, $"{model.Name}Service.cs");
            generator.SaveToFile(jsonFile);

            Console.WriteLine($"✅ {options.ClassName} has been created successfully!");
        }




    }

    
    private static string GetTemplateService(List<string> usings, string nameSpace, string className)
    {
        // Initialize a StringBuilder to accumulate the using statements.
        StringBuilder usingStatements = new StringBuilder();

        // If the list of usings is not null, loop through each namespace and add it to the StringBuilder.
        if (usings != null)
        {
            foreach (var u in usings)
            {
                usingStatements.AppendLine($"using {u};");
            }
        }

        // Generate and return the final template as a formatted string.
        return $@"
{usingStatements.ToString()}
public interface I{className}Service<TServiceRequestDso, TServiceResponseDso>
    where TServiceRequestDso : class
    where TServiceResponseDso : class
{{
  //  Task<TServiceResponseDso> CreateAsync(TServiceRequestDso entity);
   // Task<TServiceResponseDso> GetByIdAsync(Guid id);
    // يمكنك إضافة المزيد من الدوال هنا حسب الحاجة.
}}

public class {className}Service : BaseService, I{className}Service<{className}RequestDso, {className}ResponseDso> ///
{{
///
    private readonly I{className}ShareRepository _{className.ToLower()}ShareRepository;
///
    public {className}Service(I{className}ShareRepository {className.ToLower()}ShareRepository, IMapper mapper, ILoggerFactory logger) ///
        : base(mapper, logger)
    {{

         ///
        _{className.ToLower()}ShareRepository = {className.ToLower()}ShareRepository;
///
    }} ///

   

    // يمكنك إضافة المزيد من الدوال مثل UpdateAsync أو DeleteAsync إذا كان ذلك مطلوبًا.
}}

     ";
    }





    private static string[] UseRepositorys = new string[] { "Builder", "Share" };
    public static void GeneratWithFolder(FolderEventArgs e)
    {
        
                GenerateAll(e.Node.Name, e.Node.Name, e.Node.Name, e.FullPath);
          
            //GenerateAll(e.Node.Name, node.Name, node.Name, e.FullPath);



      
    }



}

