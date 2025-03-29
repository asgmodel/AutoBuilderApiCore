﻿using AutoGenerator.ApiFolder;
using AutoGenerator.Helper.Translation;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Options;
using System.Reflection;
using System.Text;


namespace AutoGenerator.Code;

public class DsoGenerator : GenericClassGenerator, ITGenerator
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


    public void GenrateandSave(GenerationOptions options, string path)
    {

        Generate(options);
        SaveToFile(options.ClassName);
    }




    public static void GenerateAll(string type, string subtype, string NamespaceName, string pathfile)
    {


        var assembly = Assembly.GetExecutingAssembly();


        var models = assembly.GetTypes().Where(t => typeof(ITModel).IsAssignableFrom(t) && t.IsClass).ToList();



        Type type1 = typeof(ITDso);




        foreach (var model in models)
        {
            var options = new GenerationOptions($"{model.Name}{NamespaceName}{type}", model)
            {
                NamespaceName = $"{type}.{NamespaceName}",
                AdditionalCode = @"",
                Interfaces = new List<Type> { type1 },
                Usings = new List<string> { "Microsoft.CodeAnalysis", "AutoGenerator" }

            };

            options.BaseClass = $"{model.Name}{NamespaceName}ShareDto";

            options.Usings.Add($"Dto.Share.{NamespaceName}");







            options.Properties = new List<PropertyInfo>().ToArray();
            ITGenerator generator = new DsoGenerator();
            generator.Generate(options);

            string jsonFile = Path.Combine(pathfile, $"{NamespaceName}/{options.ClassName}.cs");
            generator.SaveToFile(jsonFile);

            Console.WriteLine($"✅ {options.ClassName} has been created successfully!");
        }




    }


    public static void GeneratWithFolder(FolderEventArgs e)
    {
        foreach (var node in e.Node.Children)
        {
        
                GenerateAll(e.Node.Name, node.Name, node.Name, e.FullPath);
            


        }
    }



}

