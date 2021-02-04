using PosterShop.Models;
using System.Collections.Generic;

namespace PosterShop.ViewModels
{
    public class OrdersListViewModel
    {
        public PaginatedList<Poster> PosterOrders { get; set; }

        public decimal OrderTotal { get; set; }

        public bool HasPreviousPage { get; set; }

        public bool HasNextPage { get; set; }

        public int PageIndex { get; set; }
    }
}