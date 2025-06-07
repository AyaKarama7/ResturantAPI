using Microsoft.EntityFrameworkCore;
using Resturant.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Infrastructure.Seeders
{
    internal class ResturantSeeder(ResturantDbContext context) : IResturantSeeder
    {
        public async Task SeedAsync()
        {
            if (context.Database.GetPendingMigrations().Any())
            {
                await context.Database.MigrateAsync();
            }
            if (await context.Database.CanConnectAsync())
            {
                if (!context.Resturants.Any())
                {
                    context.Resturants.AddRange(
                        new Domain.Entities.Resturant
                        {
                            Name = "Resturant A",
                            Description = "Description A",
                            Address = new Domain.Entities.Address
                            {
                                Street = "Street A",
                                City = "City A",
                            }
                        },
                        new Domain.Entities.Resturant
                        {
                            Name = "Resturant B",
                            Description = "Description B",
                            Address = new Domain.Entities.Address
                            {
                                Street = "Street B",
                                City = "City B",
                            }
                        }
                    );
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}