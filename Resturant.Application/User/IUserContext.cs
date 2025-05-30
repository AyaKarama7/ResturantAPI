using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Application.User
{
    public interface IUserContext
    {
        CurrentUser? GetCurrentUser();
    }
}
