using Microsoft.OpenApi.Models;
using Resturant.Domain.Entities;

namespace Resturant.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPresentationServices(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddAuthentication();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                       {
                           new OpenApiSecurityScheme
                           {
                               Reference = new OpenApiReference
                               {
                                   Type = ReferenceType.SecurityScheme,
                                   Id = "bearerAuth"
                               }
                           },
                           new string[] {}
                       }
                });
            });
            
        }
    }
}
