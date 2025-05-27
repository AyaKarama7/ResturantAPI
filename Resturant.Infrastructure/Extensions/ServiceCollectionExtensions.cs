using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Resturant.Domain.IRepositories;
using Resturant.Infrastructure.Data;
using Resturant.Infrastructure.Repositories;

namespace Resturant.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructureServices(this IServiceCollection services,IConfiguration configuration)
    {
        var connectionString=configuration.GetConnectionString("ResturantDb");
        services.AddDbContext<ResturantDbContext>(options => options.UseSqlServer(connectionString));
        services.AddScoped<IResturantRepository, ResturantRepository>();
        services.AddScoped<IDishRepository, DishRepository>();
    }
}
