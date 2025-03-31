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





        var root = ApiFolderInfo.ROOT.Name;

        NamespaceName = $"{root}.Controllers.{subtype}";

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

                            $"{root}.Services.Services",
                            "Microsoft.AspNetCore.Mvc",
                            $"{root}.DyModels.VM.{model.Name}",
                            "System.Linq.Expressions",
                            $"{root}.DyModels.Dso.Requests",









                        }


            };

           

           




            ITGenerator generator = new ServiceGenerator();
            generator.Generate(options);

            string jsonFile = Path.Combine(pathfile, $"{subtype}/{model.Name}Controller.cs");
            generator.SaveToFile(jsonFile);

            Console.WriteLine($"✅ {options.ClassName} has been created successfully!");
        }




    }

    // This method generates a controller template based on provided usings, namespace, and className.
    public static string GetTemplateController(List<string> usings, string namespaceName, string className)
    {
        // Initialize StringBuilder to accumulate the using statements dynamically.
        StringBuilder usingStatements = new StringBuilder();

        // Add using statements to the StringBuilder if provided.
        if (usings != null)
        {
            foreach (var u in usings)
            {
                usingStatements.AppendLine($"using {u};");
            }
        }

        // Generate and return the controller template by replacing the namespace and className variables.
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

        // Get all {className}s.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<{className}OutputVM>>> GetAll()
        {{
            var result = await _{className.ToLower()}Service.GetAllAsync();
            var items = _mapper.Map<List<{className}OutputVM>>(result);
            return Ok(items);
        }}

        // Get a {className} by ID.
        [HttpGet(""{{id}}"")]
        public async Task<ActionResult<{className}InfoVM>> GetById(int id)
        {{
            if (id <= 0) return BadRequest(""Invalid {className} ID."");

            var {className.ToLower()} = await _{className.ToLower()}Service.GetByIdAsync(id);
            if ({className.ToLower()} == null) return NotFound();
            var item = _mapper.Map<{className}InfoVM>({className.ToLower()});
            return Ok(item);
        }}

        //// Find a {className} by a specific predicate.
        //[HttpGet(""find"")]
        //public async Task<ActionResult<{className}InfoVM>> Find([FromQuery] Expression<Func<{className}OutputVM, bool>> predicate)
        //{{
        //     return NotFound();
        //    //var {className.ToLower()} = await _{className.ToLower()}Service.FindAsync(predicate);
        //   // if ({className.ToLower()} == null) return NotFound();
        //   // var item = _mapper.Map<{className}InfoVM>({className.ToLower()});
        //   // return Ok(item);
        //}}

        // Create a new {className}.
        [HttpPost]
        public async Task<ActionResult<{className}CreateVM>> Create([FromBody] {className}CreateVM model)
        {{
            if (model == null) return BadRequest(""{className} data is required."");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var item = _mapper.Map<{className}RequestDso>(model);
            var created{className} = await _{className.ToLower()}Service.CreateAsync(item);
            var createdItem = _mapper.Map<{className}CreateVM>(created{className});
            return CreatedAtAction(nameof(GetById), new {{ id = 0 }}, createdItem);
        }}

        // Create multiple {className}s.
        [HttpPost(""createRange"")]
        public async Task<ActionResult<IEnumerable<{className}CreateVM>>> CreateRange([FromBody] IEnumerable<{className}CreateVM> models)
        {{
            if (models == null) return BadRequest(""Data is required."");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var items = _mapper.Map<List<{className}RequestDso>>(models);
            var created{className}s = await _{className.ToLower()}Service.CreateRangeAsync(items);
            var createdItems = _mapper.Map<List<{className}CreateVM>>(created{className}s);
            return CreatedAtAction(nameof(GetAll), createdItems);
        }}

        // Update an existing {className}.
        [HttpPut(""{{id}}"")]
        public async Task<IActionResult> Update(int id, [FromBody] {className}UpdateVM model)
        {{
            if (id <= 0 || model == null) return BadRequest(""Invalid data."");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var item = _mapper.Map<{className}RequestDso>(model);
            var updated{className} = await _{className.ToLower()}Service.UpdateAsync(item);
            if (updated{className} == null) return NotFound();
            var updatedItem = _mapper.Map<{className}UpdateVM>(updated{className});
            return Ok(updatedItem);
        }}

        // Delete a {className}.
        [HttpDelete(""{{id}}"")]
        public async Task<IActionResult> Delete(int id)
        {{
            if (id <= 0) return BadRequest(""Invalid {className} ID."");

            await _{className.ToLower()}Service.DeleteAsync(id);
            return NoContent();
        }}

        //// Delete multiple {className}s.
        //[HttpDelete(""deleteRange"")]
        //public async Task<IActionResult> DeleteRange([FromQuery] Expression<Func<{className}OutputVM, bool>> predicate)
        //{{
        //    //await _{className.ToLower()}Service.DeleteRangeAsync(predicate);
        //    return NoContent();
        //}}

        //// Check if a {className} exists based on a predicate.
        //[HttpGet(""exists"")]
        //public async Task<ActionResult<bool>> Exists([FromQuery] Expression<Func<{className}OutputVM, bool>> predicate)
        //{{
        //    //var exists = await _{className.ToLower()}Service.ExistsAsync(predicate);
        //    return Ok();
        //}}

        // Get count of {className}s.
        [HttpGet(""count"")]
        public async Task<ActionResult<int>> Count()
        {{
            var count = await _{className.ToLower()}Service.CountAsync();
            return Ok(count);
        }}
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

