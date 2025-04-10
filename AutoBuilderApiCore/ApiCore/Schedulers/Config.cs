using ApiCore.Validators;
using ApiCore.Validators.Conditions;
using AutoGenerator;
using AutoGenerator.Conditions;
using AutoGenerator.Schedulers;
using Quartz;
using System;
using System.Reflection;

namespace ApiCore.Schedulers
{
    public static class ConfigMScheduler
    {


        public static void AddAutoConfigScheduler(this IServiceCollection serviceCollection)
        {
            Assembly? assembly = Assembly.GetExecutingAssembly();




             serviceCollection.AddHostedService<JobScheduler>(pro =>
            {
                var jober = pro.GetRequiredService<ISchedulerFactory>();
                var checker = new ConditionChecker(null);

               var jobs= ConfigScheduler.getJobOptions(checker, assembly);

                return new JobScheduler(jober, jobs);

            });



           
        }
    }
}