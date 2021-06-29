using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLibrary.CuisineManagment
{
    public class CuisineHandler
    {

        public static void AddCusine(Cuisine entity)
        {

            using (ApplictionDb  context = new ApplictionDb())
            {
                context.Add(entity);
                context.SaveChanges();
            }

        }

        public static List<Cuisine> GetCuisines()
        {
            using (ApplictionDb context = new ApplictionDb())
            {
                return context.Cuisines.Include(x=>x.ParentCuisine).ToList();
            }
        }


    }
}
