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


    public static void GenerateAll(string root,string type, string subtype, string NamespaceName, string pathfile)
    {


        var assembly = Assembly.GetExecutingAssembly();


        var models = assembly.GetTypes().Where(t => typeof(ITModel).IsAssignableFrom(t) && t.IsClass).ToList();

        





        NamespaceName = $"{root}.Repositorys.{subtype}";

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
                            $"{root}.DyModels.Dto.Build.Requests",
                           $"{root}.DyModels.Dto.Build.Responses",
                            "AutoGenerator.Models"

                        }


            };

           

            if(subtype == "Share")
            {

                options.Usings.AddRange(new List<string> {

                            $"{root}.DyModels.Dto.Share.Requests",
                           $"{root}.DyModels.Dto.Share.Responses",


                            $"{root}.Repositorys.Builder",
                            "AutoGenerator.Repositorys.Share",
                            "System.Linq.Expressions"
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
        // Create a StringBuilder to store the using statements.
        //
        StringBuilder usingStatements = new StringBuilder();
        //

        // Check if the usings list is not null.
        //
        if (usings != null)
        {
            // Loop through each using statement and add it to StringBuilder.
            //
            foreach (var u in usings)
            {
                usingStatements.AppendLine($"using {u};"); // Append using statement with a new line.
            }
            //
        }
        //

        // Generate and return the final template as a formatted string.
        //
        return $@"
{usingStatements.ToString()}

/// <summary>
/// {className} interface for ShareRepository.
/// </summary>
public interface I{className}ShareRepository  
    : IBaseShareRepository<{className}RequestShareDto, {className}ResponseShareDto> 
     , I{className}BuilderRepository<{className}RequestShareDto, {className}ResponseShareDto> 
     //  You can add all IBuilder functions here to use them in the generated class.
{{
    // Define methods or properties specific to the share repository interface.
    //
}}
//

/// <summary>
/// {className} class for ShareRepository.
/// </summary>
public class {className}ShareRepository   //
    : BaseShareRepository<{className}RequestShareDto, {className}ResponseShareDto, {className}RequestBuildDto, {className}ResponseBuildDto>,  //
      I{className}ShareRepository //
{{
    // Declare the builder repository.
    //
    private readonly {className}BuilderRepository _builder;
    //

    /// <summary>
    /// Constructor for {className}ShareRepository.
    /// </summary>
    public {className}ShareRepository(DataContext dbContext, IMapper mapper, ILoggerFactory logger) 
        : base(mapper, logger) // Pass parameters to the base class.
    {{
        // Initialize the builder repository.
        //
        _builder = new {className}BuilderRepository(dbContext, mapper, logger.CreateLogger(typeof({className}ShareRepository).FullName));
        //
    }}
    //

    // Additional methods can be added as needed.
    //

    /// <summary>
    /// Method to count the number of entities.
    /// </summary>
    public Task<int> CountAsync() //
    {{
        // Throw an exception indicating the method is not implemented.
        //
        throw new NotImplementedException(); 
        //
    }}
    //

    /// <summary>
    /// Method to create a new entity asynchronously.
    /// </summary>
    public async Task<{className}ResponseShareDto> CreateAsync({className}RequestShareDto entity) //
    {{
        // Call the create method in the builder repository.
        //
        var result = await _builder.CreateAsync(entity);
        // Convert the result to ResponseShareDto type.
        //
        var output = ({className}ResponseShareDto)result;
        // Return the final result.
        //
        return output; 
        //
    }}
    //

    /// <summary>
    /// Method to create a range of entities asynchronously.
    /// </summary>
    public Task<IEnumerable<{className}ResponseShareDto>> CreateRangeAsync(IEnumerable<{className}RequestShareDto> entities)
    {{
        //
        throw new NotImplementedException();
        //
    }}
    //

    /// <summary>
    /// Method to delete a specific entity.
    /// </summary>
    public Task DeleteAsync(string id)
    {{
        //
        throw new NotImplementedException();
        //
    }}
    //

    /// <summary>
    /// Method to delete a range of entities based on a condition.
    /// </summary>
    public Task DeleteRangeAsync(Expression<Func<{className}ResponseShareDto, bool>> predicate)
    {{
        //
        throw new NotImplementedException();
        //
    }}
    //

    /// <summary>
    /// Method to check if an entity exists based on a condition.
    /// </summary>
    public Task<bool> ExistsAsync(Expression<Func<{className}ResponseShareDto, bool>> predicate)
    {{
        //
        throw new NotImplementedException();
        //
    }}
    //

    /// <summary>
    /// Method to find an entity based on a condition.
    /// </summary>
    public Task<{className}ResponseShareDto?> FindAsync(Expression<Func<{className}ResponseShareDto, bool>> predicate)
    {{
        //
        throw new NotImplementedException();
        //
    }}
    //

    /// <summary>
    /// Method to retrieve all entities.
    /// </summary>
    public Task<IEnumerable<{className}ResponseShareDto>> GetAllAsync()
    {{
        //
        throw new NotImplementedException();
        //
    }}
    //

    /// <summary>
    /// Method to get an entity by its unique ID.
    /// </summary>
    public Task<{className}ResponseShareDto?> GetByIdAsync(string id)
    {{
        //
        throw new NotImplementedException();
        //
    }}
    //

    /// <summary>
    /// Method to get data using a specific ID.
    /// </summary>
    public Task<{className}ResponseShareDto> getData(int id)
    {{
        //
        throw new NotImplementedException();
        //
    }}
    //

    /// <summary>
    /// Method to retrieve data as an IQueryable object.
    /// </summary>
    public IQueryable<{className}ResponseShareDto> GetQueryable()
    {{
        //
        throw new NotImplementedException();
        //
    }}
    //

    /// <summary>
    /// Method to save changes to the database.
    /// </summary>
    public Task SaveChangesAsync()
    {{
        //
        throw new NotImplementedException();
        //
    }}
    //

    /// <summary>
    /// Method to update a specific entity.
    /// </summary>
    public Task<{className}ResponseShareDto> UpdateAsync({className}RequestShareDto entity)
    {{
        //
        throw new NotImplementedException();
        //
    }}
    //
}}
";
    }


    private static string[] UseRepositorys = new string[] { "Builder", "Share" };
    public static void GeneratWithFolder(FolderEventArgs e)
    {
        foreach (var node in e.Node.Children)
        {

            if (UseRepositorys.Contains(node.Name))

                GenerateAll(ApiFolderInfo.ROOT.Name, e.Node.Name, node.Name, node.Name, e.FullPath);
          
            //GenerateAll(e.Node.Name, node.Name, node.Name, e.FullPath);



        }
    }



}

