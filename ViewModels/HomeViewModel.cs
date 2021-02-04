using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PosterShop.Models;

namespace PosterShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Poster> PostersOfTheWeek { get; set; }
    }
}
