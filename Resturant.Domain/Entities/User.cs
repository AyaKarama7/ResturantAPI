using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Domain.Entities
{
    public class User:IdentityUser
    {
        public string? ImageUrl {  get; set; }
        public List<Resturant> Resturants { get; set; } = new();
    }
}
