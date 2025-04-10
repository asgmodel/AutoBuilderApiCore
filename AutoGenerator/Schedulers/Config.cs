
using AutoGenerator.Data;
using AutoGenerator.Schedulers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quartz;
using System.Reflection;

namespace AutoGenerator.Schedulers
{


    public class OptionScheduler
    {
        
        public Assembly? Assembly { get; set; }
    }

    public  static class ConfigScheduler
    {


        //public async static void UseSchedulersCore(this WebApplication app, OptionScheduler? option=null)
        //{
        //    using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
        //    {
              

               

              
        //        var schedulerJobProvider = new SchedulerJobProvider(scope.ServiceProvider.GetRequiredService<ISchedulerFactory>(), jobOptions);

        //        await schedulerJobProvider.StartAsync();
        //    }
        
        //}
        //public static Dictionary<string,JobOptions> getJobOptions(DataContext context, Assembly assembly)
        //{
            


        //    var typesjobs = assembly.GetTypes()
        //        .Where(t => t.IsClass && !t.IsAbstract && typeof(ITJob).IsAssignableFrom(t))
        //        .AsParallel()
        //        .ToList();

        //    var jobOptions = new Dictionary<string, JobOptions>();
        //    foreach (var type in typesjobs)
        //    {
        //        var instance = Activator.CreateInstance(type, context) as ITJob;
        //        if (instance != null)
        //        {
        //            var jobOption = instance.Options;
        //            jobOption.JobType = type;
        //            jobOptions.Add(jobOption.JobName, jobOption);
        //        }


        //    }

           

        //    return jobOptions;
















        //}
    }


}
       
