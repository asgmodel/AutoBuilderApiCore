
using System.Reflection;

namespace AutoGenerator.Conditions
{
   

    public  static class ConfigValidator
    {


        public static void Register(IConditionChecker checker,Assembly assembly)
        {
            


            var validators = assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && typeof(ITValidator).IsAssignableFrom(t))
                .AsParallel()
                .ToList();

            foreach (var validator in validators)
            {
                var instance = Activator.CreateInstance(validator, checker) as ITValidator;
                //instance?.Register(checker);
            }












        }
    }


}
       
