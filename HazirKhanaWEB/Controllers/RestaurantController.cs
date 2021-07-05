using EntityLibrary.CuisineManagment;
using EntityLibrary.LocationManagment;
using HazirKhanaWEB.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HazirKhanaWEB.Helpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using HazirKhanaWEB.Extras;
using EntityLibrary.RestaurantManagment;
using Microsoft.AspNetCore.Http;
using System.IO;

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
            List<CuisineModel> cuisines = CuisineHandler.GetCuisines().ToCuisineModelList();

            List<SelectListItem> cities = LocationHandler.GetCities().ToCitySelectListItem();

            List<SelectListItem> proviences = LocationHandler.GetProviences().ToProvienceSelectListItem();

            List<SelectListItem> options = ExtrasHandler.OptionsSelectListItem();

            ViewData["Cuisines"] = cuisines;
            ViewData["Cities"] = cities;
            ViewData["Proviences"] = proviences;

            ViewData["Options"] = options;

            return View();
        }

        [HttpPost]
        public IActionResult AdminRestaurantAdd(RestaurantModel model)
        {
            model.City = LocationHandler.GetCity(model.City.Id).ToCityModel();

            model.Provience = LocationHandler.GetProvience(model.Provience.Id).ToProvienceModel();

            Restaurant restaurant = model.ToRestaurantEntity();

            //foreach (var cuisine in model.Cuisines)
            //{
            //    if (cuisine.IsChecked == false)
            //    {
            //        restaurant.Cuisines.
            //        restaurant.Cuisines.Remove(cuisine.ToCuisineEntity());
            //    }
            //}

            for (int i = 0; i < model.Cuisines.Count; i++)
            {
                if (model.Cuisines[i].IsChecked == false)
                {
                    restaurant.Cuisines.RemoveAt(i);
                }
            }

            IFormFile logo = Request.Form.Files["logo"];
            IFormFile banner = Request.Form.Files["banner"];

            restaurant.Banner = banner.FromStringToByteArray();
            restaurant.Logo = logo.FromStringToByteArray();

            RestaurantHandler.AddRestaurant(restaurant);

            return RedirectToAction("Index", "AdminHome");
        }

        public IActionResult AdminRestaurantsList()
        {
            List<RestaurantModel> restaurant = RestaurantHandler.GetRestaurants().ToRestaurantModelList();

            ViewData["Restaurants"] = restaurant;
            return View();
        }

        public IActionResult AdminSingleRestaurant(int id)
        {
            RestaurantModel restaurant = RestaurantHandler.GetRestaurant(id).ToRestaurantModel();

            ViewData["Restaurant"] = restaurant;

            return View();
        }
    }
}
