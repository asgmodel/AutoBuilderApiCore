using ApiCore.Validators;
using AutoGenerator.Schedulers;
using System;

namespace ApiCore.Schedulers
{


    public class SubscriptionJob : BaseJob
    {
        private readonly IConditionChecker _checker;
        public SubscriptionJob(IConditionChecker checker) :base(){ 
        
           _checker = checker;
        
        }
        public override Task Execute(JobEventArgs context)
        {
            Console.WriteLine($"Executing job: {_options.JobName} with cron: {_options.Cron}");
            return Task.CompletedTask;
        }

        protected override void InitializeJobOptions()
        {
            // _options.
            _options.JobName = "Subscription1";


        }
    }
}