using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Resturant.Domain.Entities;
using Resturant.Domain.IRepositories;
using Resturant.Infrastructure.Data;
using Resturant.Infrastructure.Repositories;
using Resturant.Infrastructure.Seeders;

namespace Resturant.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructureServices(this IServiceCollection services,IConfiguration configuration)
    {
        var connectionString=configuration.GetConnectionString("ResturantDb");
        services.AddDbContext<ResturantDbContext>(options => options.UseSqlServer(connectionString));
        services.AddScoped<IResturantRepository, ResturantRepository>();
        services.AddScoped<IDishRepository, DishRepository>();
        services.AddIdentityApiEndpoints<User>().AddRoles<IdentityRole>().AddEntityFrameworkStores<ResturantDbContext>();
        //services.AddIdentity<User, IdentityRole>()
        //    .AddEntityFrameworkStores<ResturantDbContext>()
        //    .AddApiEndpoints();

        services.AddScoped<ISeeder, RoleSeeder>();
        services.AddScoped<IResturantSeeder, ResturantSeeder>();

    }
}
