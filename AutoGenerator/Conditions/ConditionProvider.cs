namespace AutoGenerator.Conditions
{

    public interface IConditionProvider<TEnum> where TEnum : Enum
    {
        void Register(TEnum type, ICondition condition);
        ICondition? Get(TEnum type);
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


}
