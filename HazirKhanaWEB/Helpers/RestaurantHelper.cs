﻿using EntityLibrary.RestaurantManagment;
using HazirKhanaWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HazirKhanaWEB.Helpers
{
    public static class RestaurantHelper
    {
        public static RestaurantModel ToRestaurantModel(this Restaurant entity)
        {
            RestaurantModel model = new RestaurantModel();

            if(entity != null)
            {
                model.Id = entity.Id;
                model.Name = entity.Name;
                model.Address = entity.Address;
                model.ConatctTel = entity.ConatctTel;
                model.ContactMob = entity.ContactMob;
                model.Discription = entity.Discription;
                model.Email = entity.Email;
                model.OrderLedTime = entity.OrderLedTime;
                model.PercentageCutOff = entity.PercentageCutOff;
                model.PostalCode = entity.PostalCode;
                model.Reservation = entity.Reservation;
                model.SalesTax = entity.SalesTax;
                if (entity.Logo != null)
                {
                    model.Logo = Convert.ToBase64String(entity.Logo);
                }
                if (entity.Banner != null)
                {
                    model.Banner = Convert.ToBase64String(entity.Banner);
                }

                if (entity.City != null)
                {
                    model.City = entity.City.ToCityModel();
                }
                if (entity.Provience != null)
                {
                    model.Provience = entity.Provience.ToProvienceModel();
                }
                if(entity.Cuisines != null)
                {
                    model.Cuisines = entity.Cuisines.ToCuisineModelList();
                }
                
            }


            return model;
        }

        public static Restaurant ToRestaurantEntity(this RestaurantModel model)
        {
            Restaurant entity = new Restaurant();

            if (model != null)
            {
                entity.Id = model.Id;
                entity.Name = model.Name;
                entity.Address = model.Address;
                entity.ConatctTel = model.ConatctTel;
                entity.ContactMob = model.ContactMob;
                entity.Discription = model.Discription;
                entity.Email = model.Email;
                entity.OrderLedTime = model.OrderLedTime;
                entity.PercentageCutOff = model.PercentageCutOff;
                entity.PostalCode = model.PostalCode;
                entity.Reservation = model.Reservation;
                entity.SalesTax = model.SalesTax;

                if (model.City != null)
                {
                    entity.City = model.City.ToCityEntity();
                }
                if (model.Provience != null)
                {
                    entity.Provience = model.Provience.ToProvieceEntity();
                }
                if (model.Cuisines != null)
                {
                    entity.Cuisines = model.Cuisines.ToCuisineEntityList();
                }
            }
            return entity;
        }

        public static List<RestaurantModel> ToRestaurantModelList(this List<Restaurant> entites)
        {
            List<RestaurantModel> modelList = new List<RestaurantModel>();

            if (entites != null)
            {
                foreach (var restaurant in entites)
                {
                    modelList.Add(restaurant.ToRestaurantModel());
                }
            }

            return modelList;
        }


    }
}
