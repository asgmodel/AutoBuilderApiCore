

using ApiCore.Services.Services;
using AutoGenerator.Data;
using AutoGenerator.Schedulers;

namespace ApiCore.Schedulers
{


    public class ScapeJob : BaseJob
    {

        private readonly DataContext _context;

        public ScapeJob(DataContext context) :base()
        {
            _context = context;

           


             

        }
        public override Task Execute(JobEventArgs context)
        {

            

            Console.WriteLine($"Executing job: {_options.JobName} with cron: {_options.Cron}");

            return Task.CompletedTask;
        }
     
        protected override void InitializeJobOptions()
        {

            // _options.
            _options.JobName = "space1";
            _options.Cron = "0 0/1 * * * ?"; // ﬂ· œﬁÌﬁ…

        }
    }


}