using OdoToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestauransByName(string name);
        Restaurant GetById(int id);
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

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetRestauransByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }
}
