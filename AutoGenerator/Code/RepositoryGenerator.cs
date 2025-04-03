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

    class ActionServ
    {

        public string Name { get; set; }
        public Func<string, string,string> ActionM { get; set; }

        
    }
    public static void GenerateAll(string root,string type, string subtype, string NamespaceName, string pathfile)
    {


        var assembly = Assembly.GetExecutingAssembly();


        var models = assembly.GetTypes().Where(t => typeof(ITModel).IsAssignableFrom(t) && t.IsClass).ToList();




        var funcs = subtype != "Share" ?
            new List<ActionServ>() {
             new(){ActionM=createTIRBuild,Name="I"},
             new(){ActionM=createTIRbodyBuild,Name=""}
            } :
         new List<ActionServ>() {
             new(){ActionM=createTIRShare,Name="I"},
             new(){ActionM=createTIBodyShare,Name=""}
            };

       



        NamespaceName = $"{root}.Repositorys.{subtype}";

        foreach (var model in models)
        {


            CreateFolder(pathfile, $"{subtype}/{model.Name}");
            foreach (var func in funcs)
            {
                var options = new GenerationOptions($"{model.Name}{type}", model)
                {
                    NamespaceName = NamespaceName,
                    Template =func.ActionM(model.Name,type) ,
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



                if (subtype == "Share")
                {

                    options.Usings.AddRange(new List<string> {

                            $"{root}.DyModels.Dto.Share.Requests",
                           $"{root}.DyModels.Dto.Share.Responses",


                            $"{root}.Repositorys.Builder",
                            "AutoGenerator.Repositorys.Share",
                            "System.Linq.Expressions",
                            "AutoGenerator.Repositorys.Base"
                });

                }




                    ITGenerator generator = new RepositoryGenerator();
                    generator.Generate(options);

                    string jsonFile = Path.Combine(pathfile, $"{subtype}/{model.Name}/{func.Name}{model.Name}{subtype}Repository.cs");
                    generator.SaveToFile(jsonFile);

                    Console.WriteLine($"✅ {options.ClassName} has been created successfully!");
                }
            
        }




    }

    private static void CreateFolder(string path, string namemodel)
    {

        string folderPath = Path.Combine(path, namemodel);
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
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




    static string createTIRBuild(string className, string type)
    {

        return $@"  /// <summary>
                 /// {className} interface property for BuilderRepository.
           /// </summary>
         public interface I{className}BuilderRepository<TBuildRequestDto,TBuildResponseDto>  
             : IBaseBuilderRepository<TBuildRequestDto,TBuildResponseDto> //
             where TBuildRequestDto : class  //
             where TBuildResponseDto : class //
         {{
             // Define methods or properties specific to the builder interface.
         }}
         ";
    }

    static string createTIRbodyBuild(string className, string type)
    {

        return $@"  /// <summary>
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
    static string createTIRShare(string className ,string type)
    {

        return $@"
                 /// <summary>
                /// {className} interface for {type}Repository.
                /// </summary>
               public interface I{className}ShareRepository 
                                : IBaseShareRepository<{className}RequestShareDto, {className}ResponseShareDto> //
                               
                               ,IBasePublicRepository<{className}RequestShareDto, {className}ResponseShareDto>

                               //  يمكنك  التزويد بكل  دوال   طبقة Builder   ببوابات  الطبقة   هذه نفسها      
                               //,I{className}BuilderRepository<{className}RequestShareDto, {className}ResponseShareDto>
                        {{
                            // Define methods or properties specific to the share repository interface.
                        }}";
            }



    static string createTIBodyShare(string className, string type)
    {

        return $@"
                /// <summary>
                /// {className} class for ShareRepository.
                /// </summary>
                public class {className}ShareRepository  
                    : BaseShareRepository<{className}RequestShareDto, {className}ResponseShareDto, {className}RequestBuildDto, {className}ResponseBuildDto>,  
                      I{className}ShareRepository 
                {{
                    // Declare the builder repository.
                    private readonly {className}BuilderRepository _builder;
                    // Declare a logger for the repository.
                    private readonly ILogger _logger;

                    /// <summary>
                    /// Constructor for {className}ShareRepository.
                    /// </summary>
                    public {className}ShareRepository(DataContext dbContext, IMapper mapper, ILoggerFactory logger) 
                        : base(mapper, logger)
                    {{
                        // Initialize the builder repository.
                        _builder = new {className}BuilderRepository(dbContext, mapper, logger.CreateLogger(typeof({className}ShareRepository).FullName));
                        // Initialize the logger.
                        _logger = logger.CreateLogger(typeof({className}ShareRepository).FullName);
                    }}

                    /// <summary>
                    /// Method to count the number of entities.
                    /// </summary>
                    public override Task<int> CountAsync()
                    {{
                        try
                        {{
                            _logger.LogInformation(""Counting {className} entities..."");
                            throw new NotImplementedException();
                        }}
                        catch(Exception ex)
                        {{
                            _logger.LogError(ex, ""Error in CountAsync for {className} entities."");
                            return Task.FromResult(0);
                        }}
                    }}

                    /// <summary>
                    /// Method to create a new entity asynchronously.
                    /// </summary>
                    public override async Task<{className}ResponseShareDto> CreateAsync({className}RequestShareDto entity)
                    {{
                        try
                        {{
                            _logger.LogInformation(""Creating new {className} entity..."");
                            // Call the create method in the builder repository.
                            var result = await _builder.CreateAsync(entity);
                            // Convert the result to ResponseShareDto type.
                            var output = ({className}ResponseShareDto)result;
                            _logger.LogInformation(""Created {className} entity successfully."");
                            // Return the final result.
                            return output;
                        }}
                        catch(Exception ex)
                        {{
                            _logger.LogError(ex, ""Error while creating {className} entity."");
                            return null;
                        }}
                    }}

                    /// <summary>
                    /// Method to create a range of entities asynchronously.
                    /// </summary>
                    public override Task<IEnumerable<{className}ResponseShareDto>> CreateRangeAsync(IEnumerable<{className}RequestShareDto> entities)
                    {{
                        try
                        {{
                            _logger.LogInformation(""Creating a range of {className} entities..."");
                            throw new NotImplementedException();
                        }}
                        catch(Exception ex)
                        {{
                            _logger.LogError(ex, ""Error in CreateRangeAsync for {className} entities."");
                            return Task.FromResult<IEnumerable<{className}ResponseShareDto>>(null);
                        }}
                    }}

                    /// <summary>
                    /// Method to delete a specific entity.
                    /// </summary>
                    public override Task DeleteAsync(string id)
                    {{
                        try
                        {{
                            _logger.LogInformation($""Deleting {className} entity with ID: {{id}}..."");
                            throw new NotImplementedException();
                        }}
                        catch(Exception ex)
                        {{
                            _logger.LogError(ex, $""Error while deleting {className} entity with ID: {{id}}."");
                            return Task.CompletedTask;
                        }}
                    }}

                    /// <summary>
                    /// Method to delete a range of entities based on a condition.
                    /// </summary>
                    public override Task DeleteRangeAsync(Expression<Func<{className}ResponseShareDto, bool>> predicate)
                    {{
                        try
                        {{
                            _logger.LogInformation(""Deleting a range of {className} entities based on condition..."");
                            throw new NotImplementedException();
                        }}
                        catch(Exception ex)
                        {{
                            _logger.LogError(ex, ""Error in DeleteRangeAsync for {className} entities."");
                            return Task.CompletedTask;
                        }}
                    }}

                    /// <summary>
                    /// Method to check if an entity exists based on a condition.
                    /// </summary>
                    public override Task<bool> ExistsAsync(Expression<Func<{className}ResponseShareDto, bool>> predicate)
                    {{
                        try
                        {{
                            _logger.LogInformation(""Checking existence of {className} entity based on condition..."");
                            throw new NotImplementedException();
                        }}
                        catch(Exception ex)
                        {{
                            _logger.LogError(ex, ""Error in ExistsAsync for {className} entity."");
                            return Task.FromResult(false);
                        }}
                    }}

                    /// <summary>
                    /// Method to find an entity based on a condition.
                    /// </summary>
                    public override Task<{className}ResponseShareDto?> FindAsync(Expression<Func<{className}ResponseShareDto, bool>> predicate)
                    {{
                        try
                        {{
                            _logger.LogInformation(""Finding {className} entity based on condition..."");
                            throw new NotImplementedException();
                        }}
                        catch(Exception ex)
                        {{
                            _logger.LogError(ex, ""Error in FindAsync for {className} entity."");
                            return Task.FromResult<{className}ResponseShareDto>(null);
                        }}
                    }}

                    /// <summary>
                    /// Method to retrieve all entities.
                    /// </summary>
                    public override Task<IEnumerable<{className}ResponseShareDto>> GetAllAsync()
                    {{
                        try
                        {{
                            _logger.LogInformation(""Retrieving all {className} entities..."");
                            throw new NotImplementedException();
                        }}
                        catch(Exception ex)
                        {{
                            _logger.LogError(ex, ""Error in GetAllAsync for {className} entities."");
                            return Task.FromResult<IEnumerable<{className}ResponseShareDto>>(null);
                        }}
                    }}

                    /// <summary>
                    /// Method to get an entity by its unique ID.
                    /// </summary>
                    public override Task<{className}ResponseShareDto?> GetByIdAsync(string id)
                    {{
                        try
                        {{
                            _logger.LogInformation($""Retrieving {className} entity with ID: {{id}}..."");
                            throw new NotImplementedException();
                        }}
                        catch(Exception ex)
                        {{
                            _logger.LogError(ex, $""Error in GetByIdAsync for {className} entity with ID: {{id}}."");
                            return Task.FromResult<{className}ResponseShareDto>(null);
                        }}
                    }}

                    /// <summary>
                    /// Method to get data using a specific ID.
                    /// </summary>
                    public  Task<{className}ResponseShareDto> getData(int id)
                    {{
                        try
                        {{
                            _logger.LogInformation($""Getting data for {className} entity with numeric ID: {{id}}..."");
                            throw new NotImplementedException();
                        }}
                        catch(Exception ex)
                        {{
                            _logger.LogError(ex, $""Error in getData for {className} entity with numeric ID: {{id}}."");
                            return Task.FromResult<{className}ResponseShareDto>(null);
                        }}
                    }}

                    /// <summary>
                    /// Method to retrieve data as an IQueryable object.
                    /// </summary>
                    public override IQueryable<{className}ResponseShareDto> GetQueryable()
                    {{
                        try
                        {{
                            _logger.LogInformation(""Retrieving IQueryable<{className}ResponseShareDto> for {className} entities..."");
                            throw new NotImplementedException();
                        }}
                        catch(Exception ex)
                        {{
                            _logger.LogError(ex, ""Error in GetQueryable for {className} entities."");
                            return null;
                        }}
                    }}

                    /// <summary>
                    /// Method to save changes to the database.
                    /// </summary>
                    public Task SaveChangesAsync()
                    {{
                        try
                        {{
                            _logger.LogInformation(""Saving changes to the database for {className} entities..."");
                            throw new NotImplementedException();
                        }}
                        catch(Exception ex)
                        {{
                            _logger.LogError(ex, ""Error in SaveChangesAsync for {className} entities."");
                            return Task.CompletedTask;
                        }}
                    }}

                    /// <summary>
                    /// Method to update a specific entity.
                    /// </summary>
                    public override Task<{className}ResponseShareDto> UpdateAsync({className}RequestShareDto entity)
                    {{
                        try
                        {{
                            _logger.LogInformation(""Updating {className} entity..."");
                            throw new NotImplementedException();
                        }}
                        catch(Exception ex)
                        {{
                            _logger.LogError(ex, ""Error in UpdateAsync for {className} entity."");
                            return Task.FromResult<{className}ResponseShareDto>(null);
                        }}
                    }}
                }}";
    }






    private static string GetTemplatShare(List<string> usings, string nameSpace, string className)
{
    // Create a StringBuilder to store the using statements.
    StringBuilder usingStatements = new StringBuilder();

    // Check if the usings list is not null.
    if (usings != null)
    {
        // Loop through each using statement and add it to StringBuilder.
        foreach (var u in usings)
        {
            usingStatements.AppendLine($"using {u};");
        }
    }

    // Generate and return the final template as a formatted string.
    return $@"
{usingStatements.ToString()}

/// <summary>
/// {className} interface for ShareRepository.
/// </summary>
public interface I{className}ShareRepository  
    : IBaseShareRepository<{className}RequestShareDto, {className}ResponseShareDto> 
     , I{className}BuilderRepository<{className}RequestShareDto, {className}ResponseShareDto>
{{
    // Define methods or properties specific to the share repository interface.
}}

/// <summary>
/// {className} class for ShareRepository.
/// </summary>
public class {className}ShareRepository  
    : BaseShareRepository<{className}RequestShareDto, {className}ResponseShareDto, {className}RequestBuildDto, {className}ResponseBuildDto>,  
      I{className}ShareRepository 
{{
    // Declare the builder repository.
    private readonly {className}BuilderRepository _builder;
    // Declare a logger for the repository.
    private readonly ILogger _logger;

    /// <summary>
    /// Constructor for {className}ShareRepository.
    /// </summary>
    public {className}ShareRepository(DataContext dbContext, IMapper mapper, ILoggerFactory logger) 
        : base(mapper, logger)
    {{
        // Initialize the builder repository.
        _builder = new {className}BuilderRepository(dbContext, mapper, logger.CreateLogger(typeof({className}ShareRepository).FullName));
        // Initialize the logger.
        _logger = logger.CreateLogger(typeof({className}ShareRepository).FullName);
    }}

    /// <summary>
    /// Method to count the number of entities.
    /// </summary>
    public Task<int> CountAsync()
    {{
        try
        {{
            _logger.LogInformation(""Counting {className} entities..."");
            throw new NotImplementedException();
        }}
        catch(Exception ex)
        {{
            _logger.LogError(ex, ""Error in CountAsync for {className} entities."");
            return Task.FromResult(0);
        }}
    }}

    /// <summary>
    /// Method to create a new entity asynchronously.
    /// </summary>
    public async Task<{className}ResponseShareDto> CreateAsync({className}RequestShareDto entity)
    {{
        try
        {{
            _logger.LogInformation(""Creating new {className} entity..."");
            // Call the create method in the builder repository.
            var result = await _builder.CreateAsync(entity);
            // Convert the result to ResponseShareDto type.
            var output = ({className}ResponseShareDto)result;
            _logger.LogInformation(""Created {className} entity successfully."");
            // Return the final result.
            return output;
        }}
        catch(Exception ex)
        {{
            _logger.LogError(ex, ""Error while creating {className} entity."");
            return null;
        }}
    }}

    /// <summary>
    /// Method to create a range of entities asynchronously.
    /// </summary>
    public Task<IEnumerable<{className}ResponseShareDto>> CreateRangeAsync(IEnumerable<{className}RequestShareDto> entities)
    {{
        try
        {{
            _logger.LogInformation(""Creating a range of {className} entities..."");
            throw new NotImplementedException();
        }}
        catch(Exception ex)
        {{
            _logger.LogError(ex, ""Error in CreateRangeAsync for {className} entities."");
            return Task.FromResult<IEnumerable<{className}ResponseShareDto>>(null);
        }}
    }}

    /// <summary>
    /// Method to delete a specific entity.
    /// </summary>
    public Task DeleteAsync(string id)
    {{
        try
        {{
            _logger.LogInformation($""Deleting {className} entity with ID: {{id}}..."");
            throw new NotImplementedException();
        }}
        catch(Exception ex)
        {{
            _logger.LogError(ex, $""Error while deleting {className} entity with ID: {{id}}."");
            return Task.CompletedTask;
        }}
    }}

    /// <summary>
    /// Method to delete a range of entities based on a condition.
    /// </summary>
    public Task DeleteRangeAsync(Expression<Func<{className}ResponseShareDto, bool>> predicate)
    {{
        try
        {{
            _logger.LogInformation(""Deleting a range of {className} entities based on condition..."");
            throw new NotImplementedException();
        }}
        catch(Exception ex)
        {{
            _logger.LogError(ex, ""Error in DeleteRangeAsync for {className} entities."");
            return Task.CompletedTask;
        }}
    }}

    /// <summary>
    /// Method to check if an entity exists based on a condition.
    /// </summary>
    public Task<bool> ExistsAsync(Expression<Func<{className}ResponseShareDto, bool>> predicate)
    {{
        try
        {{
            _logger.LogInformation(""Checking existence of {className} entity based on condition..."");
            throw new NotImplementedException();
        }}
        catch(Exception ex)
        {{
            _logger.LogError(ex, ""Error in ExistsAsync for {className} entity."");
            return Task.FromResult(false);
        }}
    }}

    /// <summary>
    /// Method to find an entity based on a condition.
    /// </summary>
    public Task<{className}ResponseShareDto?> FindAsync(Expression<Func<{className}ResponseShareDto, bool>> predicate)
    {{
        try
        {{
            _logger.LogInformation(""Finding {className} entity based on condition..."");
            throw new NotImplementedException();
        }}
        catch(Exception ex)
        {{
            _logger.LogError(ex, ""Error in FindAsync for {className} entity."");
            return Task.FromResult<{className}ResponseShareDto>(null);
        }}
    }}

    /// <summary>
    /// Method to retrieve all entities.
    /// </summary>
    public Task<IEnumerable<{className}ResponseShareDto>> GetAllAsync()
    {{
        try
        {{
            _logger.LogInformation(""Retrieving all {className} entities..."");
            throw new NotImplementedException();
        }}
        catch(Exception ex)
        {{
            _logger.LogError(ex, ""Error in GetAllAsync for {className} entities."");
            return Task.FromResult<IEnumerable<{className}ResponseShareDto>>(null);
        }}
    }}

    /// <summary>
    /// Method to get an entity by its unique ID.
    /// </summary>
    public Task<{className}ResponseShareDto?> GetByIdAsync(string id)
    {{
        try
        {{
            _logger.LogInformation($""Retrieving {className} entity with ID: {{id}}..."");
            throw new NotImplementedException();
        }}
        catch(Exception ex)
        {{
            _logger.LogError(ex, $""Error in GetByIdAsync for {className} entity with ID: {{id}}."");
            return Task.FromResult<{className}ResponseShareDto>(null);
        }}
    }}

    /// <summary>
    /// Method to get data using a specific ID.
    /// </summary>
    public Task<{className}ResponseShareDto> getData(int id)
    {{
        try
        {{
            _logger.LogInformation($""Getting data for {className} entity with numeric ID: {{id}}..."");
            throw new NotImplementedException();
        }}
        catch(Exception ex)
        {{
            _logger.LogError(ex, $""Error in getData for {className} entity with numeric ID: {{id}}."");
            return Task.FromResult<{className}ResponseShareDto>(null);
        }}
    }}

    /// <summary>
    /// Method to retrieve data as an IQueryable object.
    /// </summary>
    public IQueryable<{className}ResponseShareDto> GetQueryable()
    {{
        try
        {{
            _logger.LogInformation(""Retrieving IQueryable<{className}ResponseShareDto> for {className} entities..."");
            throw new NotImplementedException();
        }}
        catch(Exception ex)
        {{
            _logger.LogError(ex, ""Error in GetQueryable for {className} entities."");
            return null;
        }}
    }}

    /// <summary>
    /// Method to save changes to the database.
    /// </summary>
    public Task SaveChangesAsync()
    {{
        try
        {{
            _logger.LogInformation(""Saving changes to the database for {className} entities..."");
            throw new NotImplementedException();
        }}
        catch(Exception ex)
        {{
            _logger.LogError(ex, ""Error in SaveChangesAsync for {className} entities."");
            return Task.CompletedTask;
        }}
    }}

    /// <summary>
    /// Method to update a specific entity.
    /// </summary>
    public Task<{className}ResponseShareDto> UpdateAsync({className}RequestShareDto entity)
    {{
        try
        {{
            _logger.LogInformation(""Updating {className} entity..."");
            throw new NotImplementedException();
        }}
        catch(Exception ex)
        {{
            _logger.LogError(ex, ""Error in UpdateAsync for {className} entity."");
            return Task.FromResult<{className}ResponseShareDto>(null);
        }}
    }}
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

