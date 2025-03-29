﻿using AutoGenerator.Code;
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









    public static void Build(string projectPath, string nameRoot = "Api")
    {

        if (string.IsNullOrEmpty(projectPath))
        {
            projectPath = Directory.GetCurrentDirectory().Split("bin")[0];
        }
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
           

           DtoGenerator.GeneratWithFolder(e);


        }
        else if (e.Node.Name == "Dso")
        {


        }
    }


}

   
