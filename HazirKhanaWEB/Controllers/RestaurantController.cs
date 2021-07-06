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

        [HttpGet]
        public IActionResult AdminSingleRestaurant(int id)
        {
            RestaurantModel restaurant = RestaurantHandler.GetRestaurant(id).ToRestaurantModel();

            List<CuisineModel> cuisines = CuisineHandler.GetCuisines().ToCuisineModelList();
            List<SelectListItem> cities = LocationHandler.GetCities().ToCitySelectListItem();

            List<SelectListItem> proviences = LocationHandler.GetProviences().ToProvienceSelectListItem();

            ViewData["Cities"] = cities;
            ViewData["Proviences"] = proviences;

            for (int i = 0; i < cuisines.Count; i++)
            {
                foreach (var item in restaurant.Cuisines)
                {
                    if (item.Id == cuisines[i].Id)
                    {
                        cuisines[i].IsChecked = true;
                    }
                }
            }



            ViewData["Restaurant"] = restaurant;
            ViewData["Cuisines"] = cuisines;

            return View();
        }

        [HttpPost]
        public IActionResult AdminRestaurantUpdate(RestaurantModel model)
        {
            if (model.City != null)
            {
                model.City = LocationHandler.GetCity(model.City.Id).ToCityModel();
            }
            if (model.Provience != null)
            {
                model.Provience = LocationHandler.GetProvience(model.Provience.Id).ToProvienceModel();
            }


            Restaurant restaurant = model.ToRestaurantEntity();

            for (int i = 0; i < model.Cuisines.Count; i++)
            {
                if (model.Cuisines[i].IsChecked == false)
                {
                    restaurant.Cuisines.RemoveAt(i);
                }
            }

            RestaurantModel restaurantModel = RestaurantHandler.GetRestaurant(model.Id).ToRestaurantModel();


            if (model.Logo != null)
            {
                IFormFile logo = Request.Form.Files["logo"];
                restaurant.Logo = logo.FromStringToByteArray();
            }
            if (model.Banner != null)
            {
                IFormFile banner = Request.Form.Files["banner"];
                restaurant.Banner = banner.FromStringToByteArray();
            }

            RestaurantHandler.RestaurantAdminUpdate(restaurant);

            return RedirectToAction("AdminRestaurantList");
        }
    }
}
