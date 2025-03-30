using AutoGenerator.ApiFolder;
using AutoGenerator.Helper.Translation;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Options;
using System.Reflection;
using System.Text;


namespace AutoGenerator.Code;

public class RepositoryGenerator : GenericClassGenerator, ITGenerator
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

        





        NamespaceName = $"Repositorys.{subtype}";

        foreach (var model in models)
        {
            var options = new GenerationOptions($"{model.Name}{type}", model)
            {
                NamespaceName= NamespaceName,
                Template = subtype != "Share"?GetTemplateBuilder(null, NamespaceName, model.Name):
                            GetTemplatShare(null, NamespaceName, model.Name),
                Usings = new List<string>
                        {
                            "AutoGenerator.Data",
                            "AutoMapper",
                         
                            "Microsoft.Extensions.Logging",
                            "System.Collections.Generic",
                    
                            "AutoGenerator.Repositorys.Builder",
                            "Dto.Build.Requests",
                            "Dto.Build.Responses",
                            "AutoGenerator.Models"

                        }


            };

           

            if(subtype == "Share")
            {

                options.Usings.AddRange(new List<string> {
                            
                            "Dto.Share.Requests",
                            "Dto.Share.Responses",
                          
                
                            "Repositorys.Builder",
                            "AutoGenerator.Repositorys.Share"
                });
            }





            ITGenerator generator = new RepositoryGenerator();
            generator.Generate(options);

            string jsonFile = Path.Combine(pathfile, $"{subtype}/{model.Name}{subtype}Repository.cs");
            generator.SaveToFile(jsonFile);

            Console.WriteLine($"✅ {options.ClassName} has been created successfully!");
        }




    }

    
    private static string GetTemplateBuilder(List<string> usings, string nameSpace, string className)
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

             /// <summary>
                 /// {className} interface property for BuilderRepository.
           /// </summary>
         public interface I{className}BuilderRepository<TBuildRequestDto,TBuildResponseDto>  
             : IBaseBuilderRepository<TBuildRequestDto,TBuildResponseDto> //
             where TBuildRequestDto : class  //
             where TBuildResponseDto : class //
         {{
             // Define methods or properties specific to the builder interface.
         }}
         
         //

         /// <summary>
                 /// {className} class property for BuilderRepository.
           /// </summary>
         //
         

        public class {className}BuilderRepository   
             : BaseBuilderRepository<{className},{className}RequestBuildDto,{className}ResponseBuildDto>,  
               I{className}BuilderRepository<{className}RequestBuildDto,{className}ResponseBuildDto>
         {{
                       /// <summary>
                         /// Constructor for {className}BuilderRepository.
                   /// </summary>


             public {className}BuilderRepository(DataContext dbContext,
                                               IMapper mapper, ILogger logger) 
                 : base(dbContext, mapper, logger) // Initialize  constructor.
             {{
                 // Initialize necessary fields or call base constructor.
                ///
                /// 

       
                /// 
             }}


         //

          // Add additional methods or properties as needed.
         }}
     ";
    }





    private static string GetTemplatShare(List<string> usings, string nameSpace, string className)
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
         /// <summary>
/// {className} interface property for ShareRepository.
/// </summary>
public interface I{className}ShareRepository  
    : IBaseShareRepository<{className}RequestShareDto, {className}ResponseShareDto> 
     //, I{className}BuilderRepository<{className}RequestShareDto, {className}ResponseShareDto> 
     //  يمكنك   تزويد  بكل دوال   Ibuilder  هنا   بحيث يمكنك استخدامها في الكلاس الذي سيتم توليده
{{
    // Define methods or properties specific to the share repository interface.
}}

/// <summary>
/// {className} class property for ShareRepository.
/// </summary>
public class {className}ShareRepository   //
    : BaseShareRepository<{className}RequestShareDto, {className}ResponseShareDto, {className}RequestBuildDto, {className}ResponseBuildDto>,  //
      I{className}ShareRepository //
{{

     /// <summary>
    /// BuilderRepository 
    /// </summary>


    private readonly {className}BuilderRepository _builder;

    /// <summary>
    /// Constructor for {className}ShareRepository.
    /// </summary>
    public {className}ShareRepository(DataContext dbContext, IMapper mapper, ILoggerFactory logger) 
        : base(mapper, logger) //
    {{ 
          
        // Initialize constructor.

    
         _builder = new {className}BuilderRepository(dbContext,mapper,logger.CreateLogger(typeof({className}ShareRepository).FullName));
       
         //
        //
    }} //

    // Add additional methods or properties as needed.
}}

        ";
    }

    private static string[] UseRepositorys = new string[] { "Builder", "Share" };
    public static void GeneratWithFolder(FolderEventArgs e)
    {
        foreach (var node in e.Node.Children)
        {

            if (UseRepositorys.Contains(node.Name))

                GenerateAll(e.Node.Name, node.Name, node.Name, e.FullPath);
          
            //GenerateAll(e.Node.Name, node.Name, node.Name, e.FullPath);



        }
    }



}

