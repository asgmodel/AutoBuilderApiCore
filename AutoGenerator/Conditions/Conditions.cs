using AutoGenerator.Data;
using AutoGenerator.Helper.Translation;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Reflection;
using System.Threading.Tasks; 

namespace AutoGenerator.Conditions
{
    public class ConditionResult
    {
        public bool? Success { get; set; }
        public object? Result { get; set; }
        public string? Message { get; set; }

        public ConditionResult(bool success, object result, string message = "")
        {
            Success = success;
            Result = result;
            Message = message;
        }
    }

    public interface ICondition
    {
        string Name { get; }
        string? ErrorMessage { get; }
    

        Task<ConditionResult> Evaluate(object context);
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

        // ���� ��� ������� ���
        public abstract Task<ConditionResult> Evaluate(object context);

        
    }

    // Implementation of async evaluation with ConditionResult
    public class LambdaCondition<T> : BaseCondition
    {
        private readonly Func<T, Task<ConditionResult>> _predicate;

        public LambdaCondition(string name, Func<T, object> predicate, string? errorMessage = null)
            : base(name, errorMessage)
        {

            _predicate = ConvertToConditionResult(predicate,errorMessage);
        }

        public LambdaCondition(string name, Func<T, ConditionResult> predicate, string? errorMessage = null)
            : base(name, errorMessage)
        {
            _predicate = ConvertToConditionResult(predicate);
        }

        public LambdaCondition(string name, Func<T, Task<ConditionResult>> predicate, string? errorMessage = null)
            : base(name, errorMessage)
        {
            _predicate =predicate;
        }

        private static Func<T, Task<ConditionResult>> ConvertToConditionResult(Func<T, object> predicate,string errorMessage)
        {

            if (predicate == null)
            {

                throw new ArgumentNullException(nameof(predicate));

            }
            return (T context) =>
            {
                var result = predicate(context);
                if (result is bool flag)

                    return Task.FromResult(new ConditionResult(flag, result, errorMessage));
                
                return Task.FromResult(new ConditionResult(true, result, errorMessage));
            };
        }

        private static Func<T, Task<ConditionResult>> ConvertToConditionResult(Func<T, ConditionResult> predicate)
        {

            if (predicate == null)
            {

                throw new ArgumentNullException(nameof(predicate));

            }
            return (T context) =>
            {
             
                return Task.FromResult(predicate(context));
            };
        }



        public override async Task<ConditionResult> Evaluate(object context) 
        {
            try
            {
                if (context is T typedContext)
                {
                    // ������� await �� ���� ������� ��� ���� ��� �������
                    ConditionResult result = await _predicate(typedContext);
                    return result;
                }

                // ��� ��� ������ ��� ������ �� ����� �����ϡ ���� ����� ���
                return new ConditionResult(false, null, $"Invalid context type: {context.GetType().Name}, expected {typeof(T).Name}");
            }
            catch (Exception ex)
            {
                // �� ���� ���� �������� ���� ����� ��� �� ��������
                return new ConditionResult(false, null, $"An error occurred: {ex.Message}");
            }
        }
    }

  
}
