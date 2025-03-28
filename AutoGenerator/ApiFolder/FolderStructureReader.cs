using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace AutoGenerator.ApiFolder
{
    /// <summary>
    /// يمثل قارئ هيكلية المجلدات من JSON.
    /// </summary>
    public class FolderStructureReader
    {
        /// <summary>
        /// تمثيل العقدة في شجرة المجلدات.
        /// </summary>
        public class FolderNode
        {
            public string Name { get; set; }
            public List<FolderNode> Children { get; set; } = new List<FolderNode>();

            public FolderNode(string name)
            {
                Name = name;
            }
        }

        private dynamic folderStructure;

        /// <summary>
        /// تحميل الهيكلية من ملف JSON.
        /// </summary>
        public void LoadFromJson(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    folderStructure = JsonConvert.DeserializeObject<dynamic>(json);
                    Console.WriteLine("✅ تم تحميل الهيكلية من الملف بنجاح.");
                }
                else
                {
                    Console.WriteLine($"❌ الملف {filePath} غير موجود.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ حدث خطأ أثناء تحميل الهيكلية: {ex.Message}");
            }
        }

        /// <summary>
        /// تحويل الهيكلية إلى شجرة FolderNode.
        /// </summary>
        public FolderNode BuildFolderTree(string folderName, dynamic structure = null)
        {
            structure = structure ?? folderStructure;
            FolderNode node = new FolderNode(folderName);

            if (structure is JObject)
            {
                foreach (var property in ((JObject)structure).Properties())
                {
                    FolderNode childNode = BuildFolderTree(property.Name, property.Value);
                    node.Children.Add(childNode);
                }
            }
            else if (structure is JArray)
            {
                foreach (var item in (JArray)structure)
                {
                    if (item.Type == JTokenType.String)
                    {
                        FolderNode childNode = new FolderNode(item.ToString());
                        node.Children.Add(childNode);
                    }
                    else if (item is JObject)
                    {
                        foreach (var property in ((JObject)item).Properties())
                        {
                            FolderNode childNode = BuildFolderTree(property.Name, property.Value);
                            node.Children.Add(childNode);
                        }
                    }
                }
            }
            else if (structure is JValue)
            {
                node.Children.Add(new FolderNode(structure.ToString()));
            }

            return node;
        }

        /// <summary>
        /// طباعة شجرة المجلدات للتأكد من صحتها.
        /// </summary>
        public void PrintFolderTree(FolderNode node, string indent = "")
        {
            Console.WriteLine(indent + node.Name);
            foreach (var child in node.Children)
            {
                PrintFolderTree(child, indent + "  ");
            }
        }

        /// <summary>
        /// إنشاء المجلدات على النظام وإضافة ملف Base.cs داخل كل منها.
        /// </summary>
        public void CreateFolders(string basePath, FolderNode node)
        {
            try
            {
                string folderPath = Path.Combine(basePath, node.Name);

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                    Console.WriteLine($"📁 تم إنشاء المجلد: {folderPath}");
                }
                if (node.Children == null||node.Children.Count==0)
                {
                    // إنشاء ملف Base.cs داخل المجلد
                    string baseFilePath = Path.Combine(folderPath, "Base.cs");
                    if (!File.Exists(baseFilePath))
                    {
                        var parent = folderPath.Split("\\");
                        if (parent.Length > 1)
                        {
                            var nameSpace =$"{parent[parent.Length - 1]}{parent[parent.Length - 2]}";
                          


                            File.WriteAllText(baseFilePath, GetBaseClassTemplate($"Base{node.Name}", nameSpace: $"{nameSpace}"));
                            Console.WriteLine($"📝 تم إنشاء الملف: {baseFilePath}");
                        }
                    }
                }
                // تنفيذ نفس العملية لجميع المجلدات الفرعية
                foreach (var child in node.Children)
                {
                    CreateFolders(folderPath, child);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ حدث خطأ أثناء إنشاء المجلدات والملفات: {ex.Message}");
            }
        }

        /// <summary>
        /// إرجاع كود `Base.cs` بناءً على اسم المجلد.
        /// </summary>
        private string GetBaseClassTemplate(string className,string nameSpace= "generatecode")
        {
            return $@"using System;

namespace {nameSpace}
{{
    public class {className}
    {{
        public {className}()
        {{
            Console.WriteLine(""Base class initialized in {className}"");
        }}
    }}
}}";
        }
    }

  

}
