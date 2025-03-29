using AutoGenerator.Code;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.PortableExecutable;
using static AutoGenerator.ApiFolder.FolderStructureReader;
namespace AutoGenerator.ApiFolder;


public static class ApiFolderInfo
{

    public static FolderNode? ROOT { get; set; }
    private static string? absolutePath;





}
public class ApiFolderGenerator
{

    public static FolderNode? ROOT { get; set; }

    private static string? absolutePath;





    public static string? AbsolutePath { get => absolutePath; }


    public static void Build(string projectPath, string nameRoot = "Api")
    {

        if (string.IsNullOrEmpty(projectPath))
        {
            projectPath = Directory.GetCurrentDirectory().Split("bin")[0];
        }
        absolutePath = projectPath;
        string jsonFilePath = Path.Combine(projectPath, "folderStructure.json");

        FolderStructureReader folderReader = new FolderStructureReader();
        folderReader.FolderCreated += OnCreateFolders;

        folderReader.FileCreating += OnCreateFiles;
        folderReader.LoadFromJson(jsonFilePath);

        var root = folderReader.BuildFolderTree(nameRoot);

        folderReader.PrintFolderTree(root);
        folderReader.CreateFolders(projectPath, root);
     

        folderReader.OnAfterCreatedFolders(projectPath, root);

        Console.WriteLine("✅ All folders have been created successfully!");


        

    }

    private static void OnCreateFiles(object? sender, FileEventArgs e)
    {



       
    }

    private static void OnCreateFolders(object? sender, FolderEventArgs e)
    {
        if (e.Node.Name == "Dto")
        {
            DtoGenerator generator = new DtoGenerator();

            foreach (var node in e.Node.Children)
            {
                foreach (var child in node.Children)
                {
                    DtoGenerator.GenerateBuild(e.Node.Name,node.Name ,child.Name, e.FullPath);
                }
                

            }


        }
    }


}

   
