using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLibrary.RestaurantManagment
{
    public class RestaurantHandler
    {
        public static void AddRestaurant(Restaurant entity)
        {
            using (ApplictionDb context = new ApplictionDb())
            {

                if (entity != null)
                {
                    if (entity.Products != null)
                    {
                        foreach (var product in entity.Products)
                        {
                            context.Entry(product).State = EntityState.Unchanged;
                        }

                    }

                    if (entity.Cuisines != null)
                    {
                        foreach (var cuisine in entity.Cuisines)
                        {
                            context.Entry(cuisine).State = EntityState.Unchanged;
                        }
                    }
                    if (entity.City != null)
                    {
                        context.Entry(entity.City).State = EntityState.Unchanged;
                    }
                    if (entity.Provience != null)
                    {
                        context.Entry(entity.Provience).State = EntityState.Unchanged;
                    }

                    context.Add(entity);
                    context.SaveChanges();
                }

            }

        }

        public static List<Restaurant> GetRestaurants()
        {
            using (ApplictionDb context = new ApplictionDb())
            {
                return context.Restaurants.ToList();
            }
        }

        public static Restaurant GetRestaurant(int id)
        {
            using (ApplictionDb context = new ApplictionDb())
            {
                return (from Restaurant in context.Restaurants where Restaurant.Id == id select Restaurant).FirstOrDefault();
            }
        }


    }
}
