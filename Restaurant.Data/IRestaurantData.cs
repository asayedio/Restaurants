using Restaurants.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Restaurant.Data
{
    public interface IRestaurantData
    {
        IEnumerable<RestaurantClass> GetAll();
    }
    public class InMomoryRestaurantData : IRestaurantData
    {
        List<RestaurantClass> restaurants;
        public InMomoryRestaurantData()
        {
            restaurants = new List<RestaurantClass>() { 
                new RestaurantClass{ID=1,Name="KFC",Location="Cairo",Cuisine= CuisineType.Egyptian},
                new RestaurantClass{ID=2,Name="MAC",Location="Cairo",Cuisine= CuisineType.Mexican},
                new RestaurantClass{ID=1,Name="Pizza Hut",Location="Cairo",Cuisine= CuisineType.Italian}
            };
        }
        public IEnumerable<RestaurantClass> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }
    }
}
