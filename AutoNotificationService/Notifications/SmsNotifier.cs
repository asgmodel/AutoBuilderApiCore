﻿namespace AutoNotificationService.Notifications;
public interface ISmsNotifier : IProviderNotifier
{
}
public class SmsNotifier : ISmsNotifier
{
    public NotificationType Type => NotificationType.Sms;

    public bool HasNotifierModel<T>(T model) where T : class
    {
        // تحقق من وجود النموذج
        return true;
    }

    public async Task<ResultNotifier> NotifyAsyn<T>(T model) where T : class
    {
        return new ResultNotifier { Type = NotificationType.Sms };
    }
}

