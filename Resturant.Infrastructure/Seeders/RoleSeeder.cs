using Microsoft.AspNetCore.Identity;
using Resturant.Domain.Constants;
using Resturant.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Infrastructure.Seeders
{
    internal class RoleSeeder(ResturantDbContext context) : ISeeder
    {
        public async Task SeedAsync()
        {
            if (await context.Database.CanConnectAsync())
            {
                if(!context.Roles.Any())
                {
                    var roles = GetRoles();
                    context.Roles.AddRange(roles);
                    await context.SaveChangesAsync();
                }
            }
        }

        private IEnumerable<IdentityRole> GetRoles()
        {
            List<IdentityRole> roles = new()
               {
                   new(UserRoles.Admin),
                   new(UserRoles.User),
                   new(UserRoles.Owner)
               };
            return roles;
        }
    }
}
