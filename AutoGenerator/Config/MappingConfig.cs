


using AutoGenerator.Conditions;
using AutoGenerator.Helper.Translation;
using AutoGenerator.Repositorys.Share;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Security.Cryptography;

namespace AutoGenerator.Config
{

     
    public static class AutoConfigall
    {
       
        public static void AddAutoScope(this IServiceCollection serviceCollection, Assembly? assembly)
        {

            var scopes = assembly.GetTypes().Where(t => typeof(ITScope).IsAssignableFrom(t) ).AsParallel().ToList();
            var Iscopeshare = scopes.Where(t => typeof(ITBaseShareRepository).IsAssignableFrom(t) && t.IsInterface).AsParallel().ToList();
            var cscopeshare = scopes.Where(t => typeof(ITBaseShareRepository).IsAssignableFrom(t) && t.IsClass).AsParallel().ToList();
              foreach (var Iscope in Iscopeshare)
            {

                var cscope= cscopeshare.Where(t => Iscope.IsAssignableFrom(t)).FirstOrDefault();
                if(cscope != null)
                {
                    serviceCollection.AddScoped(Iscope, cscope);
                }
                else
                {

                }
               
            }

            var Iscopeservis = scopes.Where(t => typeof(ITBaseService).IsAssignableFrom(t) && t.IsInterface).AsParallel().ToList();
            var cscopeservis = scopes.Where(t => typeof(ITBaseService).IsAssignableFrom(t) && t.IsClass).AsParallel().ToList();
            foreach (var Iscope in Iscopeservis)
            {
                if(!Iscope.Name.Contains("IUse"))
                {
                    continue;
                }
                var cscope = cscopeservis.Where(t => Iscope.IsAssignableFrom(t)).FirstOrDefault();
                if (cscope != null)
                {
                    serviceCollection.AddScoped(Iscope, cscope);
                }
            }





        }

        public static void AddAutoSingleton(this IServiceCollection serviceCollection, Assembly? assembly)
        {
          
            var singletons = assembly.GetTypes().Where(t => typeof(ITSingleton).IsAssignableFrom(t) && t.IsClass).ToList();
            foreach (var singleton in singletons)
            {
                serviceCollection.AddSingleton(singleton);
            }


            serviceCollection.AddSingleton<IConditionChecker>(provider =>
            {
                var checker =new  ConditionChecker();
                ConfigValidator.Register(checker, assembly);
                return checker;

            });
            
        }

        public static void AddAutoTransient(this IServiceCollection serviceCollection, Assembly? assembly)
        {
         
            var transients = assembly.GetTypes().Where(t => typeof(ITTransient).IsAssignableFrom(t) && t.IsClass).ToList();
            foreach (var transient in transients)
            {
                serviceCollection.AddTransient(transient);
            }
        }

    }

    public class MappingConfig : Profile
    {


        public static bool CheckIgnoreAutomateMapper(Type type)
        {
            var attribute = type.GetCustomAttribute<IgnoreAutomateMapperAttribute>();

            // Return true if the attribute exists and IgnoreMapping is true, otherwise false
            return attribute != null && attribute.IgnoreMapping;
        }

        public  static Assembly? AssemblyShare { get; set; }
        public MappingConfig()
        {

            
            var assembly = AssemblyShare;

            var assemblymodel = Assembly.GetExecutingAssembly();

            var models = assemblymodel.GetTypes().Where(t => typeof(ITModel).IsAssignableFrom(t) && t.IsClass).ToList();

            var dtos = assembly.GetTypes().Where(t => typeof(ITBuildDto).IsAssignableFrom(t) && t.IsClass).ToList();
            var dtosshare = assembly.GetTypes().Where(t => typeof(ITShareDto).IsAssignableFrom(t) && t.IsClass).ToList();

            var vms = assembly.GetTypes().Where(t => typeof(ITVM).IsAssignableFrom(t) && t.IsClass).ToList();
            var dsos = assembly.GetTypes().Where(t => typeof(ITDso).IsAssignableFrom(t) && t.IsClass).ToList();


            // map daynamic  Model and DTO
            foreach (var model in models)
            {

                if (!CheckIgnoreAutomateMapper(model))
                {


                    var dtoMatches = dtos.Where(d => d.Name.Contains(model.Name, StringComparison.OrdinalIgnoreCase)).ToList();
                    foreach (var dto in dtoMatches)
                    {

                        CreateMap(model, dto).AfterMap((src, dest,context) =>
                        {


                            HelperTranslation.MapToProcessAfter(src, dest, context);

                        });

                        CreateMap(dto,model).AfterMap((src, dest, context) =>
                        {


                            HelperTranslation.MapToProcessAfter(src, dest, context);

                        });


                        if (!CheckIgnoreAutomateMapper(dto))
                        {
                            var dtosharMatches = dtosshare.Where(d => d.Name.Contains(model.Name, StringComparison.OrdinalIgnoreCase)).ToList();
                            foreach (var share in dtosharMatches)
                            {
                                CreateMap(dto, share).ReverseMap();

                                var dsosMatches = dsos.Where(d => d.Name.Contains(model.Name, StringComparison.OrdinalIgnoreCase)).ToList();
                                foreach (var dso in dsosMatches)
                                {
                                    CreateMap(share, dso).ReverseMap();
                                }

                            }



                        }

                    }

                }
            }



            //  map daynamic  VM and DSO

            foreach (var dso in dsos)
            {
                if (!CheckIgnoreAutomateMapper(dso))
                {
                    var vmMatches = vms;//.Where(v => v.Name.Contains(dso.Name.Replace("RequestDso", "").Replace("ResponseDso", ""), StringComparison.OrdinalIgnoreCase)).ToList();
                    foreach (var vm in vmMatches)
                    {
                        if (!CheckIgnoreAutomateMapper(vm))
                        {
                            CreateMap(dso, vm).AfterMap((src, dest, context) =>
                            {


                                HelperTranslation.MapToProcessAfter(src, dest, context);

                            });

                            CreateMap(vm,dso).AfterMap((src, dest, context) =>
                            {


                                HelperTranslation.MapToProcessAfter(src, dest, context);

                            });
                        }
                    }
                }
            }
        }
    }
}