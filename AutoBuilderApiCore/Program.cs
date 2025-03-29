using AutoGenerator;
using AutoGenerator.ApiFolder;
using Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
/// <summary>
/// generate
///
if (args.Contains("generate"))
{

    builder.Services.AddAutoBuilderApiCore(new()
    {
        //ProjectPath = Directory.GetCurrentDirectory().Split("bin")[0],
        NameRootApi = "ApiCore"
    });


}
else
{


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