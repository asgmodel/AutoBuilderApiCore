using AutoGenerator.ApiFolder;
using AutoGenerator.Helper.Translation;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Options;
using System.Reflection;
using System.Text;
using AutoGenerator.TM;

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
                            "AutoGenerator.Repositorys.Base",
                            "AutoGenerator"
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

        return TmShareRepository.GetTmShareRepository(className);
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

