using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosterShop.Models
{
    public interface IUserRepository
    {
        User GetUser();

        bool IsUserLoggedIn();
    }

}
