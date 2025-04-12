using AutoGenerator.ApiFolder;
using AutoGenerator.Config;
using AutoGenerator.Helper.Translation;
using AutoGenerator.TM;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;


namespace AutoGenerator.Code;

public class SchedulerGenerator : GenericClassGenerator, ITGenerator
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

   public  static void  CinfgGenerate(string type, string subtype, string NamespaceName, string pathfile)
    {

        var root = ApiFolderInfo.ROOT.Name;

        ITGenerator generator = new SchedulerGenerator();

        NamespaceName = $"{root}.Schedulers";
        var option1 = new GenerationOptions("t", typeof(SchedulerGenerator), isProperties: false)
        {
            NamespaceName = $"{NamespaceName}",
            Template = TmSchedulers.GetTmConfigScheduler("")
                               ,
            Usings = new List<string>
                        {
                            "Quartz",
                            $"{root}.Validators",

                            "AutoGenerator.Schedulers",

                            "System.Reflection"

                        }


        };

        //

        generator.Generate(option1);

        string jsonFile = Path.Combine(pathfile, $"Config.cs");
        generator.SaveToFile(jsonFile);

        Console.WriteLine($"✅ {option1.ClassName} has been created successfully!");




    }


    public static void InjoctorGenerate(string type, string subtype, string NamespaceName, string pathfile)
    {

        var root = ApiFolderInfo.ROOT.Name;
     
    }


    public static void CheckerGenerate(string type, string subtype, string NamespaceName, string pathfile)
    {

       
    }





    public static void GenerateAll(string type, string subtype, string NamespaceName, string pathfile)
    {


        var assembly = ApiFolderInfo.AssemblyModels;


        var models = assembly.GetTypes().Where(t => typeof(ITModel).IsAssignableFrom(t) && t.IsClass).ToList();




        var root = ApiFolderInfo.ROOT.Name;




        NamespaceName = $"{root}.Schedulers";


        foreach (var model in models)
        {







            var attribute = model.GetCustomAttribute<SchedulerEnabledAttribute>();

            // Return true if the attribute exists and IgnoreMapping is true, otherwise false

            if (attribute != null && attribute.IsSchedulerped)
            {

                var options = new GenerationOptions(model.Name, model, isProperties: false)
                {
                    NamespaceName = NamespaceName,
                    Template = TmSchedulers.GetTmScheduler(model.Name)
                               ,
                    Usings = new List<string>
                        {
                            "AutoGenerator.Schedulers",
                            $"{root}.Validators"






                        }


                };

                ITGenerator generator = new SchedulerGenerator();
                generator.Generate(options);

                string jsonFile = Path.Combine(pathfile, $"{model.Name}Job.cs");
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


     

      public static void GeneratWithFolder(FolderEventArgs e)
        {

        CinfgGenerate(e.Node.Name, e.Node.Name, e.Node.Name, e.FullPath);

        InjoctorGenerate(e.Node.Name, e.Node.Name, e.Node.Name, e.FullPath);

        CheckerGenerate(e.Node.Name, e.Node.Name, e.Node.Name, e.FullPath);



        GenerateAll(e.Node.Name, e.Node.Name, e.Node.Name, e.FullPath);





        }



    }


