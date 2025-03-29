using AutoGenerator.Code;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Xunit;

namespace AutoGenerator
{
    public class Test
    {

       

        public class TestClass
         {

            public class Invoice:ITModel
            {
                [ToTranslation]
                public string Id { get; set; }
                public int Itd { get; set; }
                public string CustomerId { get; set; }
                public string Status { get; set; }
                public string Url { get; set; }
                public DateTime? InvoiceDate { get; set; }
                public string Description { get; set; }
            }

            public class ModelAi : ITModel
            {
                [Key]
                public string Id { get; set; } = $"mod_{Guid.NewGuid():N}";
                public required string Name { get; set; }
                public string? Token { get; set; }
                public string? AbsolutePath { get; set; }
                public string? Category { get; set; }
                public string? Language { get; set; }
                public bool? IsStandard { get; set; }
                public string? Gender { get; set; }

                public string? Dialect { get; set; }
                public string? Type { get; set; }

                public string? ModelGatewayId { get; set; }

            }

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
