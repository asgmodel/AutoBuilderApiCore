using ApiCore.Validators;
using AutoGenerator.Schedulers;

namespace ApiCore.Schedulers
{


    public class ScapeJob : BaseJob

    {

        private readonly IConditionChecker _checker;
        public ScapeJob(IConditionChecker  checker) :base(){

            
            
            _checker = checker;




         
        }
        public override Task Execute(JobEventArgs context)
        {
           var  item=_checker.Check(SpaceValidatorStates.IsFull, context);
            
            Console.WriteLine($"Executing job: {_options.JobName} with cron: {_options.Cron}");

            return Task.CompletedTask;
        }

        protected override void InitializeJobOptions()
        {

            // _options.
            _options.JobName = "space1";
            _options.Cron = CronSchedule.EveryMinute;



          
           

        }



       
    }


}