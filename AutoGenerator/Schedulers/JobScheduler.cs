using AutoGenerator.Config;
using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Spi;
using System.Reflection;
namespace AutoGenerator.Schedulers;
public class JobScheduler : IHostedService
{
    private readonly ISchedulerFactory _schedulerFactory;
    private IScheduler _scheduler;


    private readonly Assembly? assemblyShare;



    public JobScheduler(ISchedulerFactory schedulerFactory,Assembly assembly)
    {
      
        _schedulerFactory = schedulerFactory;
        assemblyShare = assembly;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _scheduler = await _schedulerFactory.GetScheduler();

        if(assemblyShare != null)
        {
          
       
        var types = assemblyShare?.GetTypes()?
            .Where(t => t.GetInterfaces().Contains(typeof(ITJob)) && !t.IsAbstract);
            foreach (var type in types)
            {

                //

                var objob = Activator.CreateInstance(type) as BaseJob;

                IJobDetail job = JobBuilder.Create(type)

                .WithIdentity(objob.Options.JobName,
                    objob.Options.JobGroup)
                .Build();

                ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity(
                        objob.Options.TriggerName,
                        objob.Options.TriggerGroup)
                    .StartNow()
                    .WithCronSchedule(
                        objob.Options.Cron)
                    .Build();



                await _scheduler.ScheduleJob(job, trigger);
            }
        }
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        
        if (_scheduler != null)
        {
            await _scheduler.Shutdown();
        }
    }
}

