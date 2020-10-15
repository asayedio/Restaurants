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
        IEnumerable<RestaurantClass> GetRestaurantsByName(string name);
        RestaurantClass GetRestaurantById(int id);
        RestaurantClass UpdateRestaurant(RestaurantClass updatedRestaurant);
        RestaurantClass AddRestaurant(RestaurantClass newRestaurant);
        RestaurantClass DeleteRestaurant(int id);
        int Commit();
    }
    public class InMomoryRestaurantData : IRestaurantData
    {
        List<RestaurantClass> restaurants;
        public InMomoryRestaurantData()
        {
            restaurants = new List<RestaurantClass>() { 
                new RestaurantClass{ID=1,Name="KFC",Location="Cairo",Cuisine= CuisineType.Egyptian},
                new RestaurantClass{ID=2,Name="MAC",Location="Cairo",Cuisine= CuisineType.Mexican},
                new RestaurantClass{ID=3,Name="Pizza Hut",Location="Cairo",Cuisine= CuisineType.Italian}
            };
        }
        public IEnumerable<RestaurantClass> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }
        public IEnumerable<RestaurantClass> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
        public RestaurantClass GetRestaurantById(int id)
        {
            return restaurants.SingleOrDefault(r => r.ID == id);
        }
        public RestaurantClass UpdateRestaurant(RestaurantClass updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.ID == updatedRestaurant.ID);
            if(restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }
        public RestaurantClass AddRestaurant(RestaurantClass newRestaurant)
        {
            newRestaurant.ID = restaurants.Max(r => r.ID) + 1;
            restaurants.Add(newRestaurant);
            return newRestaurant;
        }
        public RestaurantClass DeleteRestaurant(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.ID == id);
            if(restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }
        public int Commit()
        {
            return 0;
        }
    }
}
