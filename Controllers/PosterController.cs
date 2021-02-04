using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PosterShop.Models;
using PosterShop.ViewModels;

namespace PosterShop.Controllers
{
        public class PosterController : Controller
        {
            private readonly IPosterRepository posterRepository;
            private readonly ICategoryRepository categoryRepository;

            public PosterController(IPosterRepository posterRepository, ICategoryRepository categoryRepository)
            {
                this.posterRepository = posterRepository;
                this.categoryRepository = categoryRepository;
            }

            public IActionResult List(string category)
            {
                try
                { 
                    IEnumerable<Poster> posters;
                    string currentCategory;

                    if (string.IsNullOrEmpty(category))
                    {
                        posters = posterRepository.AllPosters.OrderBy(p => p.PosterId);
                        currentCategory = "All Posters";
                    }
                    else
                    {
                        posters = posterRepository.AllPosters.Where(p => p.Category.CategoryName == category).OrderBy(p => p.PosterId);
                        currentCategory = categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
                    }

                    return View(new PosterListViewModel
                    {
                        Posters = posters,
                        CurrentCategory = currentCategory
                    });
                }
                catch (Exception ex)
                {
                    //Log error
                }

                return NotFound();
            }


            public IActionResult Details(int id)
            {
                var poster = posterRepository.GetPosterById(id);
                if (poster == null)
                    return NotFound();

                return View(poster);
            }
        }
    }

