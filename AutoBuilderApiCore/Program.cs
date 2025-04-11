//using ApiCore.Validators.Conditions;
using ApiCore.Schedulers;
using ApiCore.Validators.Conditions;
using AutoGenerator;

using AutoGenerator.Data;
using AutoGenerator.Schedulers;
using LAHJAAPI.Data;
using LAHJAAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


using System.Reflection;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
     .AddEntityFrameworkStores<DataContext>()
     .AddDefaultTokenProviders();
/// <summary>
/// generate
///





builder.Services.
    AddAutoBuilderApiCore(new()
    {

        Arags = args,
        NameRootApi = "ApiCore",
        IsMapper = true,
        TypeContext = typeof(DataContext),
        Assembly = Assembly.GetExecutingAssembly(),
        AssemblyModels = typeof(LAHJAAPI.Models.Advertisement).Assembly,
        DbConnectionString= builder.Configuration.GetConnectionString("DefaultConnection"),

    }).
    AddAutoValidator().
    AddAutoConfigScheduler();




var app = builder.Build();
app.UseSchedulerDashboard();

    //app.UseSchedulersCore(new OptionScheduler()
    //{
    //    Assembly = Assembly.GetExecutingAssembly(),



//});

// Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
 
    app.UseHttpsRedirection();
    

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
