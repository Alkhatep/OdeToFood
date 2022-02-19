using OdoToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Vinnys", Location = "Maadi", Cuisine = CuisineType.Italian},
                new Restaurant { Id = 2, Name = "Sizzler", Location = "Nasr city", Cuisine = CuisineType.Mexican},
                new Restaurant { Id = 3, Name = "Mahraga", Location = "Maadi", Cuisine = CuisineType.Indian},
            };
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }
    }
}
