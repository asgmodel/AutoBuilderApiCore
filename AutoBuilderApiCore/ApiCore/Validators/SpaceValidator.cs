using AutoGenerator;
using AutoGenerator.Helper.Translation;
using AutoGenerator.Conditions;
using ApiCore.DyModels.Dso.ResponseFilters;
using System;
using System.Threading.Tasks;
using ApiCore.Validators.Conditions;

namespace ApiCore.Validators
{
    public class SpaceValidator : BaseValidator<SpaceResponseFilterDso, SpaceValidatorStates>, ITValidator
    {
        private readonly ITFactoryInjector  Injector;


        public SpaceValidator(IConditionChecker checker) : base(checker)
        {
           
            Injector=checker.Injector;
        }

        protected override void InitializeConditions()
        {
            _provider.Register(SpaceValidatorStates.IsActive, 
                new LambdaCondition<SpaceResponseFilterDso>(nameof(SpaceValidatorStates.IsActive), 
                context => IsActive(context), "Space is not active"));
      
        
        
        
        }




        private  bool IsActive(SpaceResponseFilterDso context)
        {
            if (context != null)
            {
                return true;
            }
            
            
            var resultt = _checker.Check(SubscriptionValidatorStates.IsActive, context.Subscription);
           
          return resultt;
        
        
        }

        private ConditionResult IsAyyyctive(SpaceResponseFilterDso context)
        {
           




            List<ConditionResult> conditions = new List<ConditionResult>();

            conditions.Add(new ConditionResult(true, null, ""));


            return new ConditionResult(true, conditions, "");


        }



    } //
    //  Base
    public  enum  SpaceValidatorStates //
    { IsActive ,  IsFull ,  IsValid ,  //
    }

}