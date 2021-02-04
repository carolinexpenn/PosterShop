using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PosterShop.ViewModels;

namespace PosterShop.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.UserMessage = string.Format($"Thank you {model.Name} for getting in touch. Someone shall respond shortly.");
                ModelState.Clear();
            }

            return View(model);
        }
    }
}
