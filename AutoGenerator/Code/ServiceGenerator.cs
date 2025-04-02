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




        var root = ApiFolderInfo.ROOT.Name;


        NamespaceName = $"{root}.Services.{subtype}";

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
                            $"{root}.DyModels.Dso.Requests",
                            $"{root}.DyModels.Dso.Responses",
                            "AutoGenerator.Models",
                            $"{root}.DyModels.Dto.Share.Requests",
                            $"{root}.DyModels.Dto.Share.Responses",


                            $"{root}.Repositorys.Share",
                            "System.Linq.Expressions",
                            $"{root}.Repositorys.Builder"



                        }


            };

           

           




            ITGenerator generator = new ServiceGenerator();
            generator.Generate(options);

            string jsonFile = Path.Combine(pathfile, $"{model.Name}Service.cs");
            generator.SaveToFile(jsonFile);

            Console.WriteLine($"✅ {options.ClassName} has been created successfully!");
        }




    }

    private static string GetTemplateService(List<string> usings, string nameSpace, string className) // 
    { // 
      // Initialize a StringBuilder to accumulate the using statements. // 
        StringBuilder usingStatements = new StringBuilder(); // 
                                                             // If the list of usings is not null, loop through each namespace and add it to the StringBuilder. // 
        if (usings != null) // 
        { // 
            foreach (var u in usings) // 
            { // 
                usingStatements.AppendLine($"using {u};"); // 
            } // 
        } // 
          // Generate and return the final template as a formatted string. // 
        return $@"
{usingStatements.ToString()}
public interface I{className}Service<TServiceRequestDso, TServiceResponseDso> // 
    where TServiceRequestDso : class // 
    where TServiceResponseDso : class // 
{{ // 
    // Example method definitions: // 
    // Task<TServiceResponseDso> CreateAsync(TServiceRequestDso entity); // 
    // Task<TServiceResponseDso> GetByIdAsync(Guid id); // 
    // يمكنك إضافة المزيد من الدوال هنا حسب الحاجة. // 
}} // 


public interface IUse{className}Service : I{className}BuilderRepository<{className}RequestDso, {className}ResponseDso>, I{className}Service<{className}RequestDso, {className}ResponseDso>, IBaseService // 
{{ // 
    // يمكنك إضافة دوال إضافية هنا حسب الحاجة. // 
}} // 


public class {className}Service : BaseService<{className}RequestDso, {className}ResponseDso>, IUse{className}Service // 
{{ // 
    private readonly I{className}ShareRepository _builder; // 
    private readonly ILogger _logger; // 

    public {className}Service(I{className}ShareRepository {className.ToLower()}ShareRepository, IMapper mapper, ILoggerFactory logger) // 
        : base(mapper, logger) // 
    {{ // 
        _builder = {className.ToLower()}ShareRepository; // 
        _logger = logger.CreateLogger(typeof({className}Service).FullName); // 
    }} // 

    /// <summary> // 
    /// Method to count the number of entities. // 
    /// </summary> // 
    public Task<int> CountAsync() // 
    {{ // 
        try // 
        {{ // 
            _logger.LogInformation(""Counting {className} entities...""); // 
            throw new NotImplementedException(); // 
        }} // 
        catch(Exception ex) // 
        {{ // 
            _logger.LogError(ex, ""Error in CountAsync for {className} entities.""); // 
            return Task.FromResult(0); // 
        }} // 
    }} // 

    /// <summary> // 
    /// Method to create a new entity asynchronously. // 
    /// </summary> // 
    public async Task<{className}ResponseDso> CreateAsync({className}RequestDso entity) // 
    {{ // 
        try // 
        {{ // 
            _logger.LogInformation(""Creating new {className} entity...""); // 
            var result = await _builder.CreateAsync(entity); // 
            var output = ({className}ResponseDso)result; // 
            _logger.LogInformation(""Created {className} entity successfully.""); // 
            return output; // 
        }} // 
        catch(Exception ex) // 
        {{ // 
            _logger.LogError(ex, ""Error while creating {className} entity.""); // 
            return null; // 
        }} // 
    }} // 

    /// <summary> // 
    /// Method to create a range of entities asynchronously. // 
    /// </summary> // 
    public Task<IEnumerable<{className}ResponseDso>> CreateRangeAsync(IEnumerable<{className}RequestDso> entities) // 
    {{ // 
        try // 
        {{ // 
            _logger.LogInformation(""Creating a range of {className} entities...""); // 
            throw new NotImplementedException(); // 
        }} // 
        catch(Exception ex) // 
        {{ // 
            _logger.LogError(ex, ""Error in CreateRangeAsync for {className} entities.""); // 
            return Task.FromResult<IEnumerable<{className}ResponseDso>>(null); // 
        }} // 
    }} // 

    /// <summary> // 
    /// Method to delete a specific entity. // 
    /// </summary> // 
    public Task DeleteAsync(string id) // 
    {{ // 
        try // 
        {{ // 
            _logger.LogInformation($""Deleting {className} entity with ID: {{id}}...""); // 
            throw new NotImplementedException(); // 
        }} // 
        catch(Exception ex) // 
        {{ // 
            _logger.LogError(ex, $""Error while deleting {className} entity with ID: {{id}}.""); // 
            return Task.CompletedTask; // 
        }} // 
    }} // 

    /// <summary> // 
    /// Method to delete a range of entities based on a condition. // 
    /// </summary> // 
    public Task DeleteRangeAsync(Expression<Func<{className}ResponseDso, bool>> predicate) // 
    {{ // 
        try // 
        {{ // 
            _logger.LogInformation(""Deleting a range of {className} entities based on condition...""); // 
            throw new NotImplementedException(); // 
        }} // 
        catch(Exception ex) // 
        {{ // 
            _logger.LogError(ex, ""Error in DeleteRangeAsync for {className} entities.""); // 
            return Task.CompletedTask; // 
        }} // 
    }} // 

    /// <summary> // 
    /// Method to check if an entity exists based on a condition. // 
    /// </summary> // 
    public Task<bool> ExistsAsync(Expression<Func<{className}ResponseDso, bool>> predicate) // 
    {{ // 
        try // 
        {{ // 
            _logger.LogInformation(""Checking existence of {className} entity based on condition...""); // 
            throw new NotImplementedException(); // 
        }} // 
        catch(Exception ex) // 
        {{ // 
            _logger.LogError(ex, ""Error in ExistsAsync for {className} entity.""); // 
            return Task.FromResult(false); // 
        }} // 
    }} // 

    /// <summary> // 
    /// Method to find an entity based on a condition. // 
    /// </summary> // 
    public Task<{className}ResponseDso?> FindAsync(Expression<Func<{className}ResponseDso, bool>> predicate) // 
    {{ // 
        try // 
        {{ // 
            _logger.LogInformation(""Finding {className} entity based on condition...""); // 
            throw new NotImplementedException(); // 
        }} // 
        catch(Exception ex) // 
        {{ // 
            _logger.LogError(ex, ""Error in FindAsync for {className} entity.""); // 
            return Task.FromResult<{className}ResponseDso>(null); // 
        }} // 
    }} // 

    /// <summary> // 
    /// Method to retrieve all entities. // 
    /// </summary> // 
    public Task<IEnumerable<{className}ResponseDso>> GetAllAsync() // 
    {{ // 
        try // 
        {{ // 
            _logger.LogInformation(""Retrieving all {className} entities...""); // 
            throw new NotImplementedException(); // 
        }} // 
        catch(Exception ex) // 
        {{ // 
            _logger.LogError(ex, ""Error in GetAllAsync for {className} entities.""); // 
            return Task.FromResult<IEnumerable<{className}ResponseDso>>(null); // 
        }} // 
    }} // 

    /// <summary> // 
    /// Method to get an entity by its unique ID. // 
    /// </summary> // 
    public Task<{className}ResponseDso?> GetByIdAsync(string id) // 
    {{ // 
        try // 
        {{ // 
            _logger.LogInformation($""Retrieving {className} entity with ID: {{id}}...""); // 
            throw new NotImplementedException(); // 
        }} // 
        catch(Exception ex) // 
        {{ // 
            _logger.LogError(ex, $""Error in GetByIdAsync for {className} entity with ID: {{id}}.""); // 
            return Task.FromResult<{className}ResponseDso>(null); // 
        }} // 
    }} // 

    /// <summary> // 
    /// Method to get data using a specific ID. // 
    /// </summary> // 
    public Task<{className}ResponseDso> getData(int id) // 
    {{ // 
        try // 
        {{ // 
            _logger.LogInformation($""Getting data for {className} entity with numeric ID: {{id}}...""); // 
            throw new NotImplementedException(); // 
        }} // 
        catch(Exception ex) // 
        {{ // 
            _logger.LogError(ex, $""Error in getData for {className} entity with numeric ID: {{id}}.""); // 
            return Task.FromResult<{className}ResponseDso>(null); // 
        }} // 
    }} // 

    /// <summary> // 
    /// Method to retrieve data as an IQueryable object. // 
    /// </summary> // 
    public IQueryable<{className}ResponseDso> GetQueryable() // 
    {{ // 
        try // 
        {{ // 
            _logger.LogInformation(""Retrieving IQueryable<{className}ResponseDso> for {className} entities...""); // 
            throw new NotImplementedException(); // 
        }} // 
        catch(Exception ex) // 
        {{ // 
            _logger.LogError(ex, ""Error in GetQueryable for {className} entities.""); // 
            return null; // 
        }} // 
    }} // 

    /// <summary> // 
    /// Method to save changes to the database. // 
    /// </summary> // 
    public Task SaveChangesAsync() // 
    {{ // 
        try // 
        {{ // 
            _logger.LogInformation(""Saving changes to the database for {className} entities...""); // 
            throw new NotImplementedException(); // 
        }} // 
        catch(Exception ex) // 
        {{ // 
            _logger.LogError(ex, ""Error in SaveChangesAsync for {className} entities.""); // 
            return Task.CompletedTask; // 
        }} // 
    }} // 

    /// <summary> // 
    /// Method to update a specific entity. // 
    /// </summary> // 
    public Task<{className}ResponseDso> UpdateAsync({className}RequestDso entity) // 
    {{ // 
        try // 
        {{ // 
            _logger.LogInformation(""Updating {className} entity...""); // 
            throw new NotImplementedException(); // 
        }} // 
        catch(Exception ex) // 
        {{ // 
            _logger.LogError(ex, ""Error in UpdateAsync for {className} entity.""); // 
            return Task.FromResult<{className}ResponseDso>(null); // 
        }} // 
    }} // 
}} // 
"; // 
    } // 




    private static string[] UseRepositorys = new string[] { "Builder", "Share" };
    public static void GeneratWithFolder(FolderEventArgs e)
    {
        
                GenerateAll(e.Node.Name, e.Node.Name, e.Node.Name, e.FullPath);
          
            //GenerateAll(e.Node.Name, node.Name, node.Name, e.FullPath);



      
    }



}

