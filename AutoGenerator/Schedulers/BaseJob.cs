
using Quartz;

namespace AutoGenerator.Schedulers;

public class JobOptions
{

    public Type? JobType { get; set; } 
    public JobOptions()
    {
    }
    public JobOptions(string cron)
    {
        Cron = cron;
    }
    public JobOptions(string cron, string jobName)
    {
        Cron = cron;
        JobName = jobName;
    }
    public string? Cron { get; set; } = "0 0/1 * * * ?"; // كل دقيقة
    public string JobName { get; set; } = "job1";
    public string JobGroup { get; set; } = "group1"; // مجموعة المهمة
    public string TriggerName { get; set; } = "trigger1";
    public string TriggerGroup { get; set; } = "group1"; // مجموعة الـ Trigger
    public string JobData { get; set; } = ""; // بيانات إضافية للمهمة
    public string JobDataType { get; set; } = ""; // نوع البيانات الإضافية
    public string JobDataValue { get; set; } = ""; // قيمة البيانات الإضافية

}



public class JobEventArgs : EventArgs
{
    public  JobOptions?  Options { get; set; }
    public string? Message { get; set; }
    public DateTime Timestamp { get; set; }
    public string? Status { get; set; }
    public object? AdditionalData { get; set; }
}

public class CJober : IJob
{

    public virtual Task Execute(IJobExecutionContext context)
    {
        throw new NotImplementedException();
    }
}

public interface ITJob {
    JobOptions Options { get; }
}
public abstract class BaseJob : CJober, ITJob
{
    protected readonly JobOptions _options;




    public BaseJob()
    {
        _options = new JobOptions();
        initialize();
    }
    
    public  JobOptions Options
    {
        get { return _options; }
    }
    
    private  void initialize()
    {
        InitializeJobOptions();
    }
    abstract  protected void InitializeJobOptions();

    

    public override Task Execute(IJobExecutionContext context)
    {
        var jobeventArgs = new JobEventArgs
        {
            Options = _options,
            Message = "Job executed",
            Timestamp = DateTime.Now,
            Status = "Success",
            AdditionalData = null
        };
        return Execute(jobeventArgs);
    }
    abstract public Task Execute(JobEventArgs context);





}

