using AutoGenerator.ApiFolder;
using AutoGenerator.Helper.Translation;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Options;
using System.Reflection;
using System.Text;


namespace AutoGenerator.Code;

public class VMGenerator : GenericClassGenerator, ITGenerator
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

        





       
        StringBuilder  temp= new StringBuilder();
        var root = ApiFolderInfo.ROOT.Name;

        foreach (var model in models)

        {
            NamespaceName = $"{root}.DyModels.{type}.{model.Name}";
            foreach (var subvm in UseVM)
            {

              temp.AppendLine(GetTemplateVM(null, subvm, model.Name));
            }
            var options = new GenerationOptions($"{model.Name}{type}", model,isProperties:false)
            {
                NamespaceName= NamespaceName,
                Template = temp.ToString()
                            ,
                Usings = new List<string>
                        {
                            "AutoGenerator",
                            
                         
                          

                        }


            };

           

           




            ITGenerator generator = new VMGenerator();
            generator.Generate(options);

            string jsonFile = Path.Combine(pathfile, $"{model.Name}{type}.cs");
            generator.SaveToFile(jsonFile);
            temp.Clear();
            Console.WriteLine($"✅ {options.ClassName} has been created successfully!");
        }




    }

    
    private static string GetTemplateVM(List<string> usings, string nameSpace, string className)
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
        StringBuilder pros= new StringBuilder();
        if (nameSpace == "Filter")
            pros.AppendLine(" public string?  Lg { get; set; }");

        if(nameSpace !="Create")
            pros.AppendLine(" public string?  Id { get; set; }");


        return $@"
{usingStatements.ToString()}

/// <summary>
                 /// {className}  property for VM {nameSpace}.
           /// </summary>
public class {className}{nameSpace}VM :ITVM  ///
{{
///
      {pros.ToString()}
   
  ////
}}

//

     ";
    }





    private static string[] UseVM = new string[] { "Create", "Output", "Update", "Delete", "Info", "Share","Filter" };
    public static void GeneratWithFolder(FolderEventArgs e)
    {


            GenerateAll(e.Node.Name, e.Node.Name, e.Node.Name, e.FullPath);
          
            //GenerateAll(e.Node.Name, node.Name, node.Name, e.FullPath);



      
    }



}

