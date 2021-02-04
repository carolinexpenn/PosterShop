using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosterShop.Models
{
    public class MockUserRepository : IUserRepository
    {
        public User GetUser()
        {
            var mockPosterRepository = new MockPosterRepository();

            var user = new User { FirstName = "Carrie", LastName = "Fisher", IsLoggedIn = true };
            user.PosterOrders = mockPosterRepository.AllPosters.OrderBy(e => e.PosterId); //Populate with top 5 posters.

            return user;
        }

        public bool IsUserLoggedIn()
        {
            return GetUser().IsLoggedIn;
        }
    }
}
