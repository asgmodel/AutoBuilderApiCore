namespace AutoGenerator.Conditions
{
    public interface IConditionChecker
    {
        bool Check<TEnum>(TEnum type, object context) where TEnum : Enum;
        bool CheckAll<TEnum>(object context, out Dictionary<TEnum, bool> results) where TEnum : Enum;
        bool AreAllConditionsMet<TEnum>(object context, out List<string> failedConditions) where TEnum : Enum;
        void RegisterProvider<TEnum>(IConditionProvider<TEnum> provider) where TEnum : Enum;

        object CheckAndResult<TEnum>(TEnum type, object context) where TEnum : Enum;


        ITFactoryInjector Injector { get; }
    }


    // فئة مدقق الشروط
    public class ConditionChecker : IConditionChecker
    {
        private readonly Dictionary<Type, object> _providers = new();


        private readonly ITFactoryInjector _injector;

        public ITFactoryInjector Injector => _injector;

        public ConditionChecker(ITFactoryInjector injector)
        {

            _injector = injector;
        }

        // تسجيل مزود الشروط
        public void RegisterProvider<TEnum>(IConditionProvider<TEnum> provider) where TEnum : Enum
        {
            _providers[typeof(TEnum)] = provider;

        }

        // التحقق من حالة شرط معين
        public bool Check<TEnum>(TEnum type, object context) where TEnum : Enum
        {
            if (_providers.TryGetValue(typeof(TEnum), out var rawProvider))
            {
                var provider = rawProvider as IConditionProvider<TEnum>;
                var condition = provider?.Get(type);
                if (condition != null)
                    return (bool)condition.Evaluate(context);
                return false;
            }

            throw new InvalidOperationException($"No provider registered for enum {typeof(TEnum).Name}");
        }

        public object CheckAndResult<TEnum>(TEnum type, object context) where TEnum : Enum
        {
            if (_providers.TryGetValue(typeof(TEnum), out var rawProvider))
            {
                var provider = rawProvider as IConditionProvider<TEnum>;
                var condition = provider?.Get(type);
                if (condition != null)
                    return condition.Evaluate(context);
                return false;
            }

            throw new InvalidOperationException($"No provider registered for enum {typeof(TEnum).Name}");
        }
        // التحقق من جميع الشروط
        public bool CheckAll<TEnum>(object context, out Dictionary<TEnum, bool> results) where TEnum : Enum
        {
            results = new Dictionary<TEnum, bool>();
            if (_providers.TryGetValue(typeof(TEnum), out var rawProvider))
            {
                var provider = rawProvider as IConditionProvider<TEnum>;
                if (provider != null)
                {
                    foreach (TEnum type in Enum.GetValues(typeof(TEnum)))
                    {
                        var condition = provider.Get(type);

                        var result = condition?.Evaluate(context);
                        if (result is bool boolResult)
                            results[type] = boolResult;
                        else
                            results[type] = false;



                    }
                }
            }
            return results.All(r => r.Value);  // تحقق من نجاح جميع الشروط
        }

        // التحقق من جميع الشروط وإرجاع الشروط الفاشلة
        public bool AreAllConditionsMet<TEnum>(object context, out List<string> failedConditions) where TEnum : Enum
        {
            failedConditions = new List<string>();
            if (_providers.TryGetValue(typeof(TEnum), out var rawProvider))
            {
                var provider = rawProvider as IConditionProvider<TEnum>;
                if (provider != null)
                {
                    foreach (TEnum type in Enum.GetValues(typeof(TEnum)))
                    {
                        var condition = provider.Get(type);
                        var result = condition?.Evaluate(context);
                        if (result is bool boolResult && !boolResult)
                        {
                            failedConditions.Add($"{type} failed: {condition?.ErrorMessage}");
                        }
                        else
                        if (condition == null)
                        {
                            failedConditions.Add($"{type} failed: {condition?.ErrorMessage}");
                        }
                    }
                }
            }
            return failedConditions.Count == 0;
        }



    }



}
