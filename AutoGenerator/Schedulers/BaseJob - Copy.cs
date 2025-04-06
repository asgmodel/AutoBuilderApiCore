
using Quartz;



namespace AutoGenerator.Schedulers;
public interface IJobProvider
{
    Task AddJobAsync(JobOptions options);
    Task RemoveJobAsync(string jobName);
    Task UpdateJobAsync(string jobName, JobOptions options);
    Task StartJobAsync(string jobName);
    Task PauseJobAsync(string jobName);
    Task ResumeJobAsync(string jobName);
    Task StopJobAsync(string jobName);
}


public class JobProvider : IJobProvider
{
    private readonly ISchedulerFactory _schedulerFactory;
    private IScheduler _scheduler;
    private readonly Dictionary<string, JobOptions> _jobs;

    public JobProvider(ISchedulerFactory schedulerFactory)
    {
        _schedulerFactory = schedulerFactory;
        _jobs = new Dictionary<string, JobOptions>();
    }

    // بدء الـ Scheduler
    public async Task StartAsync()
    {
        _scheduler = await _schedulerFactory.GetScheduler();
        await _scheduler.Start();
    }

    // إضافة مهمة جديدة
    public async Task AddJobAsync(JobOptions options)
    {
        if (_jobs.ContainsKey(options.JobName))
            throw new InvalidOperationException("Job already exists");

        _jobs[options.JobName] = options;

        var jobDetail = JobBuilder.Create<BaseJob>()
            .WithIdentity(options.JobName, options.JobGroup)
            .UsingJobData("JobData", options.JobData)
            .Build();

        var trigger = TriggerBuilder.Create()
            .WithIdentity(options.TriggerName, options.TriggerGroup)
            .WithCronSchedule(options.Cron)
            .Build();

        await _scheduler.ScheduleJob(jobDetail, trigger);
    }

    // إزالة مهمة
    public async Task RemoveJobAsync(string jobName)
    {
        if (!_jobs.ContainsKey(jobName))
            throw new KeyNotFoundException("Job not found");

        await _scheduler.DeleteJob(new JobKey(jobName));
        _jobs.Remove(jobName);
    }

    // تحديث مهمة
    public async Task UpdateJobAsync(string jobName, JobOptions options)
    {
        if (!_jobs.ContainsKey(jobName))
            throw new KeyNotFoundException("Job not found");

        // إزالة المهمة القديمة أولاً
        await RemoveJobAsync(jobName);

        // إضافة المهمة الجديدة
        await AddJobAsync(options);
    }

    // بدء مهمة
    public async Task StartJobAsync(string jobName)
    {
        var jobKey = new JobKey(jobName);
        await _scheduler.TriggerJob(jobKey);
    }

    // إيقاف مهمة
    public async Task StopJobAsync(string jobName)
    {
        var jobKey = new JobKey(jobName);
        await _scheduler.PauseJob(jobKey);
    }

    // استئناف مهمة
    public async Task ResumeJobAsync(string jobName)
    {
        var jobKey = new JobKey(jobName);
        await _scheduler.ResumeJob(jobKey);
    }

    // إيقاف المهمة
    public async Task PauseJobAsync(string jobName)
    {
        var jobKey = new JobKey(jobName);
        await _scheduler.PauseJob(jobKey);
    }
}
