﻿using EntityLibrary.CuisineManagment;
using HazirKhanaWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HazirKhanaWEB.Helpers
{
    public static class CuisineHelper
    {
        public static CuisineModel ToCuisineModel(this Cuisine entity)
        {
            CuisineModel model = new CuisineModel();

            if (entity != null)
            {
                model.Id = entity.Id;

                model.Name = entity.Name;

                model.Description = entity.Description;

                if (entity.Image != null)
                {
                    model.Image = Convert.ToBase64String(entity.Image);
                }

                if (entity.ParentCuisine != null)
                {
                    model.ParentCuisine = new CuisineModel() { Id = entity.ParentCuisine.Id, Name = entity.ParentCuisine.Name, Description = entity.ParentCuisine.Description };

                }
            }

            return model;
        }

        public static Cuisine ToCuisineEntity(this CuisineModel model)
        {
            Cuisine entity = new Cuisine();

            if (model != null)
            {
                entity.Id = model.Id;

                entity.Name = model.Name;

                entity.Description = model.Description;
                if (model.ParentCuisine != null)
                {
                    entity.ParentCuisine = new Cuisine() { Id = entity.ParentCuisine.Id, Name = entity.ParentCuisine.Name, Description = entity.ParentCuisine.Description };
                }
            }

            return entity;
        }

        public static List<CuisineModel> ToCuisineModelList( this List<Cuisine> entities)
        {
            List<CuisineModel> modelList = new List<CuisineModel>();

            if (entities.Count > 0)
            {
                foreach (var cuisine in entities)
                {
                    modelList.Add(cuisine.ToCuisineModel());
                }
            }
            return modelList;
        }

        public static List<Cuisine> ToCuisineEntityList(this List<CuisineModel> models)
        {
            List<Cuisine> enitiyList = new List<Cuisine>();

            if (models.Count >0)
            {
                foreach (var cuisine in models)
                {
                    enitiyList.Add(cuisine.ToCuisineEntity());
                }
            }


            return enitiyList;

        }

    }
}
