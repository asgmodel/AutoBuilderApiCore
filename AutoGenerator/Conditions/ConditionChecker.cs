using System.Threading.Tasks;

namespace AutoGenerator.Conditions
{











    public interface IConditionChecker: IBaseConditionChecker
    {
        // لا تزال قيد التطوير 

        IConditionProvider<TEnum> Include<TEnum>(TEnum type, object context) where TEnum : Enum;
        IConditionProvider<TEnum> Then<TEnum>(TEnum type, object context, Action thenAction) where TEnum : Enum;
        IConditionProvider<TEnum> After<TEnum>(TEnum type, object context, TimeSpan delay, Action afterAction) where TEnum : Enum;
        IConditionProvider<TEnum> AnyWithCallback<TEnum>(object context, Action onSuccess, Action onFailure) where TEnum : Enum;

        IConditionProvider<TEnum> When<TEnum>(TEnum type, object context, Func<bool> condition) where TEnum : Enum;
        IConditionProvider<TEnum> Until<TEnum>(TEnum type, object context, Func<bool> condition) where TEnum : Enum;
        IConditionProvider<TEnum> If<TEnum>(TEnum type, object context, Func<bool> condition, Action trueAction, Action falseAction) where TEnum : Enum;

         }


    public class ConditionChecker :BaseConditionChecker, IConditionChecker
    {
        public ConditionChecker(ITFactoryInjector injector) : base(injector)
        {
        }

        // الدوال السابقة تبقى كما هي

        public IConditionProvider<TEnum> Include<TEnum>(TEnum type, object context) where TEnum : Enum
        {
            // Implementation placeholder
            throw new NotImplementedException();
        }

        public IConditionProvider<TEnum> Then<TEnum>(TEnum type, object context, Action thenAction) where TEnum : Enum
        {
            thenAction?.Invoke();
            return Include(type, context);
        }

        public IConditionProvider<TEnum> After<TEnum>(TEnum type, object context, TimeSpan delay, Action afterAction) where TEnum : Enum
        {
            Task.Delay(delay).ContinueWith(_ => afterAction?.Invoke());
            return Include(type, context);
        }

        public IConditionProvider<TEnum> AnyWithCallback<TEnum>(object context, Action onSuccess, Action onFailure) where TEnum : Enum
        {
            // Stub for demonstration
            bool result = true; // Simulate a result
            if (result)
                onSuccess?.Invoke();
            else
                onFailure?.Invoke();
            return null!;
        }

        public IConditionProvider<TEnum> When<TEnum>(TEnum type, object context, Func<bool> condition) where TEnum : Enum
        {
            if (condition())
                return Include(type, context);
            return null!;
        }

        public IConditionProvider<TEnum> Until<TEnum>(TEnum type, object context, Func<bool> condition) where TEnum : Enum
        {
            while (!condition())
            {
                Task.Delay(100).Wait();
            }
            return Include(type, context);
        }

        public IConditionProvider<TEnum> If<TEnum>(TEnum type, object context, Func<bool> condition, Action trueAction, Action falseAction) where TEnum : Enum
        {
            if (condition())
                trueAction?.Invoke();
            else
                falseAction?.Invoke();
            return Include(type, context);
        }

        public IConditionProvider<TEnum> Repeat<TEnum>(TEnum type, object context, int times, Action eachTime) where TEnum : Enum
        {
            for (int i = 0; i < times; i++)
            {
                eachTime?.Invoke();
            }
            return Include(type, context);
        }

        public IConditionProvider<TEnum> DelayUntil<TEnum>(TEnum type, object context, Func<bool> untilCondition, TimeSpan interval, Action onSatisfied) where TEnum : Enum
        {
            Task.Run(async () =>
            {
                while (!untilCondition())
                {
                    await Task.Delay(interval);
                }
                onSatisfied?.Invoke();
            });
            return Include(type, context);
        }

        public IConditionProvider<TEnum> Chain<TEnum>(object context, params (TEnum type, Action action)[] chain) where TEnum : Enum
        {
            foreach (var (type, action) in chain)
            {
                action?.Invoke();
            }
            return null!;
        }

        public IConditionProvider<TEnum> LogIfFails<TEnum>(TEnum type, object context, Action<string> logger) where TEnum : Enum
        {
            try
            {
                var success = true; // Simulated result
                if (!success)
                {
                    logger?.Invoke($"Condition failed: {type}");
                }
            }
            catch (Exception ex)
            {
                logger?.Invoke($"Error: {ex.Message}");
            }
            return Include(type, context);
        }

        public async Task<IConditionProvider<TEnum>> CheckAsync<TEnum>(TEnum type, object context, Func<ConditionResult, Task> onChecked) where TEnum : Enum
        {
            var result = new ConditionResult(true, null, "Checked");
            await onChecked(result);
            return Include(type, context);
        }

        public IConditionProvider<TEnum> OnSuccess<TEnum>(TEnum type, object context, Action onSuccess) where TEnum : Enum
        {
            var success = true; // Simulated
            if (success)
            {
                onSuccess?.Invoke();
            }
            return Include(type, context);
        }

        public IConditionProvider<TEnum> OnFailure<TEnum>(TEnum type, object context, Action<string> onFailure) where TEnum : Enum
        {
            var success = false; // Simulated
            if (!success)
            {
                onFailure?.Invoke("Failure reason");
            }
            return Include(type, context);
        }

        public IConditionProvider<TEnum> WithPredicate<TEnum>(TEnum type, object context, Func<ICondition, bool> predicate, Action<IEnumerable<ICondition>> onMatch) where TEnum : Enum
        {
            var provider = Include(type, context);
            var matches = provider?.GetConditions(type).Where(predicate);
            if (matches != null)
            {
                onMatch(matches);
            }
            return provider;
        }
    }
}








