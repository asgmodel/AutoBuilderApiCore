
using ApiCore.DyModels.Dso.ResponseFilters;

using AutoGenerator.Conditions;

using LAHJAAPI.Data;


namespace ApiCore.Validators
{



    public enum SpaceValidatorStates
    {
        IsActive,
        IsFull,
        IsValid,
        H

    }


    public class SpaceValidator : BaseValidator<SpaceResponseFilterDso, SpaceValidatorStates>, ITValidator
    {

    
        
        public SpaceValidator(IConditionChecker checker) : base(checker)
        {

           
        }
        protected override void InitializeConditions()
        {
            _provider.Register(
                SpaceValidatorStates.IsActive,
                new LambdaCondition<SpaceResponseFilterDso>(
                    nameof(SpaceValidatorStates.IsActive),

                    context => IsActive(context),
                    "Space is not active"
                )
            );



            _provider.Register(
               SpaceValidatorStates.IsFull,
               new LambdaCondition<SpaceResponseFilterDso>(
                   nameof(SpaceValidatorStates.IsActive),

                   context => IsActive(context),
                   "Space is not active"
               )
           );





        }



        private bool IsActive(SpaceResponseFilterDso context)
        {
            if (context.IsGlobal == true &&
                _checker.Check(SubscriptionValidatorStates.IsActive, context.Subscription))
            {
                return true;
            }
            return false;
        }

        private async Task<bool> IsFull(SpaceResponseFilterDso context)
        {

            var res = await _checker.CheckAsync(SubscriptionValidatorStates.IsActive, context.Subscription);

            if (res)
            {
                return false;
            }
            return true;
        }




        private async Task<ConditionResult> IsFullResuilt(SpaceResponseFilterDso context)
        {

            var res = await _checker.CheckAndResultAsync(SubscriptionValidatorStates.IsValid, context.Subscription);


            return res;
        }


        private ConditionResult test(SpaceResponseFilterDso context)
        {






            var res = _checker.GetProvider<SubscriptionValidatorStates>().AnyPass(context);
            if (res != null)
            {
                return res.FirstOrDefault();
            }
            return new ConditionResult(false, null, "No conditions passed");

        }


    }
}
