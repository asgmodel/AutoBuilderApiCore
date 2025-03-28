using System;
using System.Collections.Generic;
using System.IO;
namespace AutoGenerator.ApiFolder;

public class ApiFolderGenerator
{
    public static void Build(string projectPath,string nameRoot="Api")
    {
        
        string jsonFilePath = Path.Combine(projectPath, "folderStructure.json");

        FolderStructureReader folderReader = new FolderStructureReader();
        folderReader.LoadFromJson(jsonFilePath);

        var root = folderReader.BuildFolderTree(nameRoot);

        // طباعة الشجرة للتأكد من صحتها
        folderReader.PrintFolderTree(root);

        // إنشاء المجلدات على النظام بناءً على الشجرة
        folderReader.CreateFolders(projectPath, root);

        Console.WriteLine("✅ تم إنشاء جميع المجلدات بنجاح!");
    }
}
