

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
        void Register(IBaseConditionChecker checker);
    }

    public abstract class BaseValidator<TContext, EValidator> : IValidator<TContext>, ITValidator
        where TContext : class
        where EValidator : Enum
    {


        protected readonly ConditionProvider<EValidator> _provider;


        protected readonly IBaseConditionChecker _checker;











        public BaseValidator(IBaseConditionChecker checker)
        {
            _provider = new ConditionProvider<EValidator>();
            _checker = checker;



            InitializeConditions();
            _checker.RegisterProvider(_provider);


        }

        public virtual void Register(IBaseConditionChecker checker)
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