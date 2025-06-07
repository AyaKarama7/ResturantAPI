using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Infrastructure.Seeders
{
    public interface ISeeder
    {
        Task SeedAsync();
    }
}
