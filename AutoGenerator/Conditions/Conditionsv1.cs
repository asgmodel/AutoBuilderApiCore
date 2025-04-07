
using AutoGenerator.Data;
using AutoGenerator.Helper.Translation;
using AutoGenerator.Models;
using AutoMapper;
using Microsoft.Extensions.Options;
using System;
using System.Reflection;
using Microsoft.AspNetCore.Identity;


namespace AutoGenerator.Conditions
{

    public interface ICondition
    {
        string Name { get; }
        string? ErrorMessage { get; }
        object Evaluate(object context);

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

        public abstract object Evaluate(object context);
    }

    public class LambdaCondition<T> : BaseCondition
    {
        private readonly Func<T, object> _predicate;

        public LambdaCondition(string name, Func<T, object> predicate, string? errorMessage = null)
            : base(name, errorMessage)
        {
            _predicate = predicate;
        }

        public override object Evaluate(object context)
        {
            if (context is T typedContext)
            {
                object result = (_predicate(typedContext));
                return result;
            }

            throw new ArgumentException($"Invalid context type: {context.GetType().Name}, expected {typeof(T).Name}");
        }
    }


 

   

}
