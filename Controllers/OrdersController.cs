using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PosterShop.Models;
using PosterShop.ViewModels;

namespace PosterShop.Controllers
{
    //[Authorize]
    public class OrdersController : Controller
    {
        private readonly IPosterRepository posterRepository;
        private readonly IUserRepository userRepository;
        private readonly ICategoryRepository categoryRepository;

        public OrdersController(IPosterRepository posterRepository, ICategoryRepository categoryRepository, IUserRepository userRepository)
        {
            this.posterRepository = posterRepository;
            this.categoryRepository = categoryRepository;
            this.userRepository = userRepository;
        }

        public IActionResult List(string orderBy, string sortOrder, int? pageNumber)
        {
            try
            {
                IEnumerable<Poster> posterOrders = userRepository.GetUser().PosterOrders;

                var total = posterOrders.Select(x => x.Price).Sum();

                sortOrder = string.IsNullOrEmpty(sortOrder) ? "desc" : sortOrder;

                if (string.IsNullOrEmpty(orderBy))
                {
                    posterOrders = posterOrders.OrderBy(e => e.Name);
                }
                else
                {
                    switch (orderBy)
                    {
                        case "Category":
                            posterOrders = sortOrder == "desc" ? posterOrders.OrderBy(e => e.Category.CategoryName) : posterOrders.OrderByDescending(e => e.Category.CategoryName);
                            ViewData["sortOrderCategory"] = sortOrder == "desc" ? "asc" : "desc";
                            ViewData["currentSort"] = "Category";
                            break;
                        case "Name":
                            posterOrders = sortOrder == "desc" ? posterOrders.OrderBy(e => e.Name) : posterOrders.OrderByDescending(e => e.Name);
                            ViewData["sortOrderName"] = sortOrder == "desc" ? "asc" : "desc";
                            ViewData["currentSort"] = "Name";
                            break;
                        case "Price":
                            posterOrders = sortOrder == "desc" ? posterOrders.OrderBy(e => e.Price) : posterOrders.OrderByDescending(e => e.Price);
                            ViewData["sortOrderPrice"] = sortOrder == "desc" ? "asc" : "desc";
                            ViewData["currentSort"] = "Price";
                            break;
                        default:
                            posterOrders = sortOrder == "desc" ? posterOrders.OrderBy(e => e.Name) : posterOrders.OrderByDescending(e => e.Name);
                            ViewData["sortOrderName"] = sortOrder == "desc" ? "asc" : "desc";
                            ViewData["currentSort"] = "Name";
                            break;
                    }
                }

                int pageSize = 3;
                var list = PaginatedList<Poster>.Create(posterOrders.AsQueryable(), pageNumber ?? 1, pageSize);

                return View(new OrdersListViewModel
                {
                    PosterOrders = list,
                    OrderTotal = total,
                    HasNextPage = list.HasNextPage,
                    HasPreviousPage = list.HasPreviousPage,
                    PageIndex = list.PageIndex
                });
            }
            catch (Exception ex)
            {
                //Log error here
            }

            return BadRequest("Unable to find posters.");
        }
    }
}
