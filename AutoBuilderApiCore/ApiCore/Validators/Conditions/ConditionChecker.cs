using ApiCore.Validators.Conditions;
using AutoGenerator.Conditions;
using System.Threading.Tasks;

namespace ApiCore.Validators
{











    public interface IConditionChecker: IBaseConditionChecker
    {
   

        public ITFactoryInjector Injector { get; }



    }


    public class ConditionChecker :BaseConditionChecker, IConditionChecker
    {
        private readonly ITFactoryInjector _injector;

        public ITFactoryInjector Injector => _injector;
        public ConditionChecker(ITFactoryInjector injector) : base()
        {
        }

        // الدوال السابقة تبقى كما هي

     
    }
}








