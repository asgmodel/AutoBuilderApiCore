using AutoGenerator.ApiFolder;
using AutoGenerator.Config;
using AutoGenerator.Schedulers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AutoGenerator
{

    public class AutoBuilderApiCoreOption
    {

        public string? ProjectPath { get; set; }
        public string? ProjectName { get; set; } = "";

        public string NameRootApi { get; set; }= "Api";

        public bool  IsAutoBuild { get; set; } = true;
        public bool IsMapper { get; set; } = true;

        public Assembly? Assembly { get; set; }
    }
    public static class ConfigServices
    {
        public static void AddAutoBuilderApiCore(this IServiceCollection serviceCollection, AutoBuilderApiCoreOption option)
        {

            if (option.IsAutoBuild)

                ApiFolderGenerator.Build(option.ProjectPath, option.NameRootApi);

            else
            {
                if (option.IsMapper)
                {
                    MappingConfig.AssemblyShare = option.Assembly;
                    serviceCollection.AddAutoMapper(typeof(MappingConfig));
                }
                if (option.Assembly != null)
                {
                    serviceCollection.AddAutoScope(option.Assembly);
                    serviceCollection.AddAutoTransient(option.Assembly);
                    serviceCollection.AddAutoSingleton(option.Assembly);

                    serviceCollection.AddQuartz(q =>
                    {
                        q.UseMicrosoftDependencyInjectionJobFactory();
                    });

                    serviceCollection.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

                    serviceCollection.AddSingleton<IHostedService, JobScheduler>(prv =>
                    {
                        var jobScheduler = new JobScheduler(prv.GetRequiredService<ISchedulerFactory>(), option.Assembly);
                        return jobScheduler;
                    });
                }

            }

        }


       


    }
}

