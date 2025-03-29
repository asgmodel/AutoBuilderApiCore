using AutoGenerator.ApiFolder;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoGenerator
{

    public class AutoBuilderApiCoreOption
    {
        public string? ProjectPath { get; set; }
        public string? ProjectName { get; set; } 

        public string NameRootApi { get; set; }= "Api";
    }
    public static class ConfigServices
    {
        public static void AddAutoBuilderApiCore(this IServiceCollection serviceCollection, AutoBuilderApiCoreOption option)
        {

            ApiFolderGenerator.Build(option.ProjectPath, option.NameRootApi);

        }


    }
}

