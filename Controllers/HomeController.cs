using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PosterShop.Models;
using PosterShop.ViewModels;

namespace PosterShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPosterRepository posterRepository;

        public HomeController(IPosterRepository posterRepository)
        {
            this.posterRepository = posterRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                PostersOfTheWeek = posterRepository.PostersOfTheWeek
            };

            return View(homeViewModel);
        }
    }
}
