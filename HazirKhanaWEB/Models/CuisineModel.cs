using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HazirKhanaWEB.Models
{
    public class CuisineModel
    {
        public int Id {get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public bool IsChecked { get; set; }

        public CuisineModel ParentCuisine { get; set; }
    }
}
