using Restaurants.Core;
using System.Collections.Generic;
using System.Text;
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
}
