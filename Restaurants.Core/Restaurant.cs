using System;

namespace Restaurants.Core
{
    public class RestaurantClass
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
