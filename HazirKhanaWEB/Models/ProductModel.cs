using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HazirKhanaWEB.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int  Price { get; set; }

        public CuisineModel Cuisine { get; set; }

        public string Image { get; set; }

        public RestaurantModel Restaurant { get; set; }

    }
}
