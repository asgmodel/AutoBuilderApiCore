using AutoGenerator.ApiFolder;
using AutoGenerator.Helper.Translation;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Options;
using System.Reflection;
using System.Text;


namespace AutoGenerator.Code;

public class ControllerGenerator : GenericClassGenerator, ITGenerator
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

        





        NamespaceName = $"Controllers.{subtype}";

        foreach (var model in models)
        {
            var options = new GenerationOptions($"{model.Name}{type}", model)
            {
                NamespaceName= NamespaceName,
                Template = GetTemplateController(null, subtype, model.Name)
                            ,
                Usings = new List<string>
                        {
                           
                            "AutoMapper",
                         
                            "Microsoft.Extensions.Logging",
                            "System.Collections.Generic",

                            "Services.Services",
                            "Microsoft.AspNetCore.Mvc",









                        }


            };

           

           




            ITGenerator generator = new ServiceGenerator();
            generator.Generate(options);

            string jsonFile = Path.Combine(pathfile, $"{subtype}/{model.Name}Controller.cs");
            generator.SaveToFile(jsonFile);

            Console.WriteLine($"✅ {options.ClassName} has been created successfully!");
        }




    }


    private static string GetTemplateController(List<string> usings, string namespaceName, string className)
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

    [Route(""api/{namespaceName}/[controller]"")]
    [ApiController]
    public class {className}Controller : ControllerBase
    {{
        private readonly IUse{className}Service _{className.ToLower()}Service;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public {className}Controller(IUse{className}Service {className.ToLower()}Service, IMapper mapper, ILoggerFactory logger)
        {{
            _{className.ToLower()}Service = {className.ToLower()}Service;
            _mapper = mapper;
            _logger = logger.CreateLogger(typeof({className}Controller).FullName);
        }}

    
                [HttpPost(""create"")]
        public async Task<IActionResult> CreateInvoice()
        {{
            return Ok();
        }}
      
        // You can add more actions like PUT, DELETE, etc., depending on the methods in your service interface.
    }}

";
    }




    private static string[] UseControllers = new string[] { "Api" };
    public static void GeneratWithFolder(FolderEventArgs e)
    {

        foreach (var node in e.Node.Children)
                 if(UseControllers.Contains(node.Name))
                 GenerateAll(e.Node.Name, node.Name, e.Node.Name, e.FullPath);
          
            //GenerateAll(e.Node.Name, node.Name, node.Name, e.FullPath);



      
    }



}

