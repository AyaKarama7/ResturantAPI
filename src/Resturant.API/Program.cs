using Resturant.Infrastructure.Extensions;
using Resturant.Application.Extensions;
using Resturant.Domain.Entities;
using Resturant.API.Extensions;
using Resturant.Infrastructure.Seeders;
using Serilog;
using Resturant.API.Middlewarea;

namespace Resturant.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddPresentationServices();
            //inject ifrastructure DbContext
            builder.Services.AddInfrastructureServices(builder.Configuration);

            builder.Services.AddApplicationServices();
            builder.Services.AddScoped<ErrorHandlingMiddleware>();
            //add serilog
            builder.Host.UseSerilog((context, config) =>
            {
                config.ReadFrom.Configuration(context.Configuration);
            });
            var app = builder.Build();

            //seed the database 
            var scope = app.Services.CreateScope();
            var seeder = scope.ServiceProvider.GetRequiredService<ISeeder>();
            await seeder.SeedAsync();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseSerilogRequestLogging();// capture logs about excuted requests
            app.UseHttpsRedirection();

            app.MapGroup("api/identity")
               .WithTags("Identity")
               .MapIdentityApi<User>();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
