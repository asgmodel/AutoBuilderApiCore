namespace AutoGenerator.Helper
{
    // Enums to define filter types
    public enum FilterOperator
    {
        Equals,
        NotEqual,
        GreaterThan,
        GreaterThanOrEqual,
        LessThan,
        LessThanOrEqual,
        Contains,
        NotContains,
        StartsWith,
        EndsWith,
        In,
        NotIn
    }

    // Logical grouping (AND / OR)
    public enum FilterLogic
    {
        And,
        Or
    }
    // Filter condition model with nested group support
    public class FilterCondition
    {
        public string? PropertyName { get; set; }
        public object? Value { get; set; }
        public FilterOperator Operator { get; set; } = FilterOperator.Equals;
        public FilterLogic Logic { get; set; } = FilterLogic.And;
        public List<FilterCondition>? Group { get; set; } // Nested conditions
    }

}
