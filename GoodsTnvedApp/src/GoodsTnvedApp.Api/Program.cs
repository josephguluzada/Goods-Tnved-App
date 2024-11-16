using System.Text.Json;
using System.Text.Json.Serialization;
using GoodsTnvedApp.Business.MappingProfiles;
using GoodsTnvedApp.Business.Services.Abstracts;
using GoodsTnvedApp.Business.Services.Concretes;
using GoodsTnvedApp.Core.Repositories;
using GoodsTnvedApp.Data.Repositories;

namespace GoodsTnvedApp.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers().AddJsonOptions(x =>
            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);;
        // var options = new JsonSerializerOptions
        // {
        //     MaxDepth = 64, // Set to a value larger than your object hierarchy depth
        //     WriteIndented = true,
        //     ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve,
        // };

        //string jsonString = JsonSerializer.Serialize(yourObject, options);

        // Repositories
        builder.Services.AddScoped<IGoodRepository, GoodRepository>();
        
        // Services
        builder.Services.AddScoped<IGoodService, GoodService>();
        builder.Services.AddAutoMapper(typeof(MappingProfile));
        
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

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
}