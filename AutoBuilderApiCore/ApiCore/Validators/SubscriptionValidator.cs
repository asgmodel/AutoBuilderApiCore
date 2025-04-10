
using ApiCore.DyModels.Dso.ResponseFilters;
using ApiCore.DyModels.VMs;
using ApiCore.Repositories.Builder;

using AutoGenerator.Conditions;

namespace ApiCore.Validators
{



    public enum SubscriptionValidatorStates
    {
        IsActive,
        IsFull,
        IsValid

    }


    public class SubscriptionValidator : BaseValidator<SubscriptionResponseFilterDso, SubscriptionValidatorStates>, ITValidator
    {
        //  ?????? ???????  ??  context   
        /// <summary>
        ///  ???????   ??  ????? ?????? ?????? ???????   
        ///checker  ???? ????????? ?? ?????? ???????   ????????? ??  
        /// </summary>
        private readonly SubscriptionBuilderRepository subscription; // ???  ???? ????  ???? ?? ??? ????   ???????? ?? ??  ????? ?????????   

        public SubscriptionValidator(IConditionChecker checker) : base(checker)
        {
            //subscription=new SubscriptionBuilderRepository(checker.Injector.DataContext,
            //    checker.Injector.Mapper,
            //     null
            //    );
        }

        protected override void InitializeConditions()
        {
            _provider.Register(
                SubscriptionValidatorStates.IsActive,
                new LambdaCondition<SubscriptionResponseFilterDso>(
                    nameof(SpaceValidatorStates.IsActive),
                    context => isAcive(context),
                    "Space is not active"
                )
            );


            _provider.Register(
                SubscriptionValidatorStates.IsValid,
                new LambdaCondition<SubscriptionOutputVM>(
                    nameof(SpaceValidatorStates.IsActive),
                    context => context.AllowedSpaces == 10,
                    "Space is not active"
                )
            );



        }


        bool isAcive(SubscriptionResponseFilterDso context)
        {
            if (context.AllowedRequests == 10)
            {
                return true;
            }
            return false;
        }
    }
}