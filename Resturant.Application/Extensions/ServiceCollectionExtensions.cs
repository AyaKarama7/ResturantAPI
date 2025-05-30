using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Resturant.Application.User;

namespace Resturant.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    { 
        var applicationAssembly = typeof(ServiceCollectionExtensions).Assembly;
        services.AddAutoMapper(applicationAssembly);
        services.AddValidatorsFromAssembly(applicationAssembly).AddFluentValidationAutoValidation();
        services.AddMediatR(config => config.RegisterServicesFromAssembly(applicationAssembly));
        services.AddScoped<IUserContext, UserContext>();
        services.AddHttpContextAccessor();
        
    }
}

