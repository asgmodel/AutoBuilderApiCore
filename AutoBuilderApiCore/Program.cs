using AutoGenerator;
using AutoGenerator.ApiFolder;
using AutoGenerator.Config;
using AutoGenerator.Data;
using Microsoft.EntityFrameworkCore;
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


if (!args.Contains("generate"))
{

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
        , IsAutoBuild = false,
        IsMapper = true,
        Assembly = Assembly.GetExecutingAssembly()
    });
    builder.Services.AddAutoMapper(typeof(MappingConfig));
    //builder.Services.AddScoped<IInvoiceShareRepository, InvoiceShareRepository>();

    //builder.Services.AddScoped<IUseInvoiceService, InvoiceService>();

    var app = builder.Build();

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