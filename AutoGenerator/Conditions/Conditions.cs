
using AutoGenerator.Helper.Translation;
using System;
using System.Reflection;

namespace AutoGenerator.Conditions
{
    
    public interface ICondition
    {
        string Name { get; }
        string? ErrorMessage { get; }
        bool Evaluate(object context);
    }

    public interface IConditionProvider<TEnum> where TEnum : Enum
    {
        void Register(TEnum type, ICondition condition);
        ICondition? Get(TEnum type);
    }



    // Implementations
    public abstract class BaseCondition : ICondition
    {
        public string Name { get; protected set; }
        public string? ErrorMessage { get; protected set; }

        public BaseCondition(string name, string? errorMessage = null)
        {
            Name = name;
            ErrorMessage = errorMessage;
        }

        public abstract bool Evaluate(object context);
    }

    public class LambdaCondition<T> : BaseCondition
    {
        private readonly Func<T, bool> _predicate;

        public LambdaCondition(string name, Func<T, bool> predicate, string? errorMessage = null)
            : base(name, errorMessage)
        {
            _predicate = predicate;
        }

        public override bool Evaluate(object context)
        {
            if (context is T typedContext)
                return _predicate(typedContext);

            throw new ArgumentException($"Invalid context type: {context.GetType().Name}, expected {typeof(T).Name}");
        }
    }

    public class ConditionProvider<TEnum> : IConditionProvider<TEnum> where TEnum : Enum
    {
        private readonly Dictionary<TEnum, ICondition> _conditions = new();

        public void Register(TEnum type, ICondition condition)
        {
            _conditions[type] = condition;
        }

        public ICondition? Get(TEnum type)
        {
            return _conditions.TryGetValue(type, out var condition) ? condition : null;
        }
    }

    public interface IConditionChecker
    {
        bool Check<TEnum>(TEnum type, object context) where TEnum : Enum;
        bool CheckAll<TEnum>(object context, out Dictionary<TEnum, bool> results) where TEnum : Enum;
        bool AreAllConditionsMet<TEnum>(object context, out List<string> failedConditions) where TEnum : Enum;
        void RegisterProvider<TEnum>(IConditionProvider<TEnum> provider) where TEnum : Enum;
    }

    // ›∆… „œﬁﬁ «·‘—Êÿ
    public class ConditionChecker : IConditionChecker
    {
        private readonly Dictionary<Type, object> _providers = new();

        //  ”ÃÌ· „“Êœ «·‘—Êÿ
        public void RegisterProvider<TEnum>(IConditionProvider<TEnum> provider) where TEnum : Enum
        {
            _providers[typeof(TEnum)] = provider;
        }

        // «· Õﬁﬁ „‰ Õ«·… ‘—ÿ „⁄Ì‰
        public bool Check<TEnum>(TEnum type, object context) where TEnum : Enum
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

        // «· Õﬁﬁ „‰ Ã„Ì⁄ «·‘—Êÿ
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
                        results[type] = condition?.Evaluate(context) ?? false;
                    }
                }
            }
            return results.All(r => r.Value);  //  Õﬁﬁ „‰ ‰Ã«Õ Ã„Ì⁄ «·‘—Êÿ
        }

        // «· Õﬁﬁ „‰ Ã„Ì⁄ «·‘—Êÿ Ê≈—Ã«⁄ «·‘—Êÿ «·›«‘·…
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
                        if (condition == null || !condition.Evaluate(context))
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
