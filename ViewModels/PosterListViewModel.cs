using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PosterShop.Models;

namespace PosterShop.ViewModels
{
    public class PosterListViewModel
    {
        public IEnumerable<Poster> Posters { get; set; }
        public string CurrentCategory { get; set; }
    }
}
