
using AutoGenerator.Data;
using AutoGenerator.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;


namespace AutoGenerator.Conditions
{

    public interface ITFactoryInjector
    {

        public DataContext DataContext { get; }

        public IMapper Mapper { get; }


        public UserManager<ApplicationUser> UserManager { get; }

        public RoleManager<IdentityRole> RoleManager { get; }



    }
    public class TFactoryInjector : ITFactoryInjector
    {

         
        public  readonly DataContext _context;
        public readonly IMapper _mapper;
        public readonly UserManager<ApplicationUser> _userManager;
        public readonly RoleManager<IdentityRole> _roleManager;


        public TFactoryInjector(
            DataContext context,
            IMapper mapper
           


            )

        {



            _context = context;
            _mapper = mapper;
           


        }

        public DataContext DataContext =>  _context;

        public IMapper Mapper => _mapper;

        public UserManager<ApplicationUser> UserManager => _userManager;

        public RoleManager<IdentityRole> RoleManager => _roleManager;
    }


}
