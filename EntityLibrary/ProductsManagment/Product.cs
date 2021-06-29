using EntityLibrary.CuisineManagment;
using EntityLibrary.RestaurantManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLibrary.ProductsManagment
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public Cuisine Cuisine { get; set; }

        public string Image { get; set; }

        public Restaurant Restaurant { get; set; }
    }
}
