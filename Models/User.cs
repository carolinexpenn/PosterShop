using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosterShop.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsLoggedIn { get; set; }
        public IEnumerable<Poster> PosterOrders { get; set; }

        public override string ToString()
        {
            return string.Format($"{FirstName} {LastName}");
        }
    }
}
