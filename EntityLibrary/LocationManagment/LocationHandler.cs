using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLibrary.LocationManagment
{
    public class LocationHandler
    {

        public static List<City> GetCities()
        {
            using (ApplictionDb context = new ApplictionDb())
            {
                return context.Cities.Include(x=>x.Provience).ToList();
            }
        }
        public static List<Provience> GetProviences()
        {
            using (ApplictionDb context = new ApplictionDb())
            {
                return context.Proviences.ToList();
            }
        }

        public static City GetCity(int Id)
        {
            using (ApplictionDb context = new ApplictionDb())
            {
                return context.Cities.Find(Id);
            }
        }

        public static Provience GetProvience(int Id)
        {
            using (ApplictionDb context = new ApplictionDb())
            {

                return context.Proviences.Find(Id);
            }
        }

    }
}
