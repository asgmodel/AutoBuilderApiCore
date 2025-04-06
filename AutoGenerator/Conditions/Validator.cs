

namespace AutoGenerator.Conditions
{

 

    /// <summary>
    /// Invoice  property for VM Create.
    /// </summary>
    /// 

    public interface IValidator<TContext>
    {
       Task<bool>  Validate(TContext entity);

      
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

        


     







        public BaseValidator()
        {
            _provider = new ConditionProvider<EValidator>();
            


            InitializeConditions();
            

        }

        public virtual void Register(IConditionChecker checker)
        {
            checker.RegisterProvider(_provider);
        }

        public Task<bool> Validate(TContext entity)
        {
            throw new NotImplementedException();
        }

        abstract protected  void InitializeConditions();
        

    }
}