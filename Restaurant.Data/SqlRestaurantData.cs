using Restaurants.Core;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace Restaurant.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly RestaurantsDbContext db;

        public SqlRestaurantData(RestaurantsDbContext db)
        {
            this.db = db;
        }
        public RestaurantClass AddRestaurant(RestaurantClass newRestaurant)
        {
            db.Add(newRestaurant);
            return newRestaurant;
        }

        public int Commit()
        {
            //return the nuum of effcted rows in db 
            return db.SaveChanges();
        }

        public RestaurantClass DeleteRestaurant(int id)
        {
            var restaurant = GetRestaurantById(id);
            if(restaurant != null)
            {
                db.Restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public IEnumerable<RestaurantClass> GetAll()
        {
            return db.Restaurants;
        }

        public RestaurantClass GetRestaurantById(int id)
        {
            return db.Restaurants.Find(id);
        }

        public IEnumerable<RestaurantClass> GetRestaurantsByName(string name)
        {
            var query = from r in db.Restaurants
                        where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                        orderby r.Name
                        select r;
            return query;
        }

        public RestaurantClass UpdateRestaurant(RestaurantClass updatedRestaurant)
        {
            //I will give u an object exists in the db update it if it diffrent than the current one .
            var entity = db.Restaurants.Attach(updatedRestaurant);
            entity.State = EntityState.Modified;
            return updatedRestaurant;
        }
    }
}
