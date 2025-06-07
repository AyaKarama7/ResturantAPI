using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Infrastructure.Seeders
{
    public interface IResturantSeeder
    {
        Task SeedAsync();
    }
}
