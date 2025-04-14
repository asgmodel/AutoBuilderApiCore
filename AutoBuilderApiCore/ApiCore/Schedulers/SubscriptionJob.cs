using ApiCore.Helper;
using ApiCore.Validators;
using AutoGenerator.Notifications;
using AutoGenerator.Schedulers;
using AutoNotificationService.Services.Email;
using System;

namespace ApiCore.Schedulers
{
    public class SubscriptionJob : BaseJob
    {
        private readonly IConditionChecker _checker;
        public SubscriptionJob(IConditionChecker checker) : base()
        {
            _checker = checker;

            
        }
      static  bool isons=false;
   
        static   string confirmationLink = "https://example.com/confirm?token=123456";
      
        public override async Task Execute(JobEventArgs context)
        {   // „À«· 
            if (!isons)
            {
                await _checker.Injector.Notifier.NotifyAsyn(new EmailModel()
                {
                    Body = TemplateTagEmail.GetConfirmationEmailHtml(confirmationLink),
                    Subject = "LHJA",
                    ToEmail = "modelasg@gmail.com"
                });


                await _checker.Injector.Notifier.NotifyAsyn(new EmailModel()
                {
                    Body = TemplateTagEmail.PasswordResetTemplate(confirmationLink),
                    Subject = "LHJA",
                    ToEmail = "modelasg@gmail.com"
                });

                await _checker.Injector.Notifier.NotifyAsyn(new EmailModel()
                {
                    Body = TemplateTagEmail.PaymentFailedTemplate(),
                    Subject = "LHJA",
                    ToEmail = "modelasg@gmail.com"
                });
                await _checker.Injector.Notifier.NotifyAsyn(new EmailModel()
                {
                    Body = TemplateTagEmail.SecurityAlertTemplate("",""),
                    Subject = "LHJA",
                    ToEmail = "modelasg@gmail.com"
                });

                await _checker.Injector.Notifier.NotifyAsyn(new EmailModel()
                {
                    Body = TemplateTagEmail.WelcomeEmailTemplate("Anas"),
                    Subject = "LHJA",
                    ToEmail = "modelasg@gmail.com"
                });
                isons =true;
            }

            Console.WriteLine($"Executing job: {_options.JobName} with cron: {_options.Cron}");
             
        }

        protected override void InitializeJobOptions()
        {
            // _options.
            _options.JobName = "Subscription1";
            _options.Cron = CronSchedule.EveryMinute;
        }
    }
}