

namespace AutoGenerator.Conditions
{



    /// <summary>
    /// Invoice  property for VM Create.
    /// </summary>
    /// 

    public interface IValidator<TContext>
    {
        Task<bool> Validate(TContext entity);


    }

    public interface ITValidator
    {
        void Register(IConditionChecker checker);
    }

    public abstract class BaseValidator<TContext, EValidator> : IValidator<TContext>, ITValidator
        where TContext : class
        where EValidator : Enum
    {


        protected readonly ConditionProvider<EValidator> _provider;


        protected readonly IConditionChecker _checker;











        public BaseValidator(IConditionChecker checker)
        {
            _provider = new ConditionProvider<EValidator>();
            _checker = checker;



            InitializeConditions();
            _checker.RegisterProvider(_provider);


        }

        public virtual void Register(IConditionChecker checker)
        {
            checker.RegisterProvider(_provider);
        }

        public Task<bool> Validate(TContext entity)
        {
            throw new NotImplementedException();
        }

        abstract protected void InitializeConditions();


    }
}