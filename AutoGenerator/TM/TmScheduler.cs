using AutoGenerator.ApiFolder;

namespace AutoGenerator.TM
{

    public class TmSchedulers
    {

    

        public static string GetTmScheduler(string classNameSchedulerTM, TmOptions options = null)
        {
            return @$"
  public class {classNameSchedulerTM}Job : BaseJob
    {{



        private readonly IConditionChecker _checker;
        public {classNameSchedulerTM}Job(IConditionChecker  checker) :base(){{

            
            
            _checker = checker;




         
        }}



        public override Task Execute(JobEventArgs context)
        {{


            Console.WriteLine($""Executing job: {{_options.JobName}} with cron: {{_options.Cron}}"");

            return Task.CompletedTask;
        }}

        protected override void InitializeJobOptions()
        {{

            // _options.
            _options.JobName = ""{classNameSchedulerTM}1"";
            _options.Cron = CronSchedule.EveryMinute;


        }}
    }}
    
";



        }

        public static string GetTmConfigScheduler(string classNameSchedulerTM, TmOptions options = null)
        {
            return @$"
 public static class ConfigMScheduler
 {{


     public static IServiceCollection AddAutoConfigScheduler(this IServiceCollection serviceCollection)
     {{
         Assembly? assembly = Assembly.GetExecutingAssembly();




          serviceCollection.AddHostedService<JobScheduler>(pro =>
         {{
             var jober = pro.GetRequiredService<ISchedulerFactory>();

             var checker = new ConditionChecker(null);

            var jobs= ConfigScheduler.getJobOptions(checker, assembly);

             return new JobScheduler(jober, jobs);

         }});



         
          return serviceCollection;



     }}

   }}
";



        }

    }

}