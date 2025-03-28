using AutoGenerator.Code;
using System.Reflection;
using Xunit;

namespace AutoGenerator
{
    public class Test
    {

       

        public class TestClass
         {

            public class Invoice
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

            [Fact]
            public static void Main()
            {
                Type modelType = typeof(Invoice);
                var options = new GenerationOptions("InvoiceDto", modelType)
                {
                    
                    NamespaceName = "MyDtos",
                    AdditionalCode = @"
              
                public void PrintDetails()
                {
                    Console.WriteLine($""Id: {Id}, CustomerId: {CustomerId}, Status: {Status}"");
                }
            ",
                    Interfaces = new List<Type> { typeof(ITDto) },
                    BaseClass = typeof(BaseDto),
                    Usings = new List<string> { "Microsoft.CodeAnalysis", "AutoGenerator" }
                };

                ITGenerator generator = new GenericClassGenerator();
                generator.Generate(options);

                // الحصول على مسار المشروع (قبل bin)
                string projectPath = Directory.GetCurrentDirectory().Split("bin")[0];
                string jsonFile = Path.Combine(projectPath, $"{options.ClassName}.cs");

                generator.SaveToFile(jsonFile);
            }


        }

    }
}
