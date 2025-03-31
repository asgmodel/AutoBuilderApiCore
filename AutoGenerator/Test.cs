using AutoGenerator.Code;
using AutoGenerator.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Xunit;

namespace AutoGenerator
{
    public class Test
    {

       

        public class TestClass
         {

          
       

            [Fact]
            public static void Main()
            {
                Type modelType = typeof(Invoice);
                
                

                var options = new GenerationOptions("InvoiceDto", modelType)
                {
                    
                    NamespaceName = "MyDtos",
                    AdditionalCode = @""
              
           
            ,
                    Interfaces = new List<Type> { typeof(ITBuildDto) },
                   
                    Usings = new List<string> { "Microsoft.CodeAnalysis", "AutoGenerator" }
                };

                ITGenerator generator = new DtoGenerator();
                generator.Generate(options);

                 
                string projectPath = Directory.GetCurrentDirectory().Split("bin")[0];
                string jsonFile = Path.Combine(projectPath, $"{options.ClassName}.cs");

                generator.SaveToFile(jsonFile);
            }


        }

    }
}
