using ApiCore.Schedulers;
using AutoGenerator;
using AutoGenerator.ApiFolder;
using AutoGenerator.Conditions;
using AutoGenerator.Config;
using AutoGenerator.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Models;

using System.Reflection;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/// <summary>
/// generate
///


if (args.Length>0&&args[0].Contains("generate"))
{
    if(args.Length>1)
    for (int i = 1; i < args.Length; i++)
       builder.Services.AddAutoBuilderApiCore(new()
       {

        //ProjectPath = Directory.GetCurrentDirectory().Split("bin")[0],
        NameRootApi = args[i],
        IsAutoBuild = true,
       
        });
    else
        builder.Services.AddAutoBuilderApiCore(new()
        {

            //ProjectPath = Directory.GetCurrentDirectory().Split("bin")[0],
            NameRootApi = "ApiCore",
            IsAutoBuild = true,

        });



}
else
{
   builder.Services.AddDbContext<DataContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


    builder.Services.AddAutoBuilderApiCore(new()
    {
        
        NameRootApi = "ApiCore"
        ,IsAutoBuild = false,
        IsMapper = true,
        Assembly = Assembly.GetExecutingAssembly()
    });
    //builder.Services.AddAutoMapper(typeof(MappingConfig));
    //builder.Services.AddScoped<IInvoiceShareRepository, InvoiceShareRepository>();

    builder.Services.AddScoped<ScapeJob>();

    var app = builder.Build();


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
}