using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HazirKhanaWEB.Controllers
{
    public class RestaurantController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AdminRestaurantList()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AdminRestaurantAdd()
        {
            return View();
        }
    }
}
