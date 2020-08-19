using System.ComponentModel.DataAnnotations;

namespace Restaurants.Core
{
    public class RestaurantClass
    {
        public int ID { get; set; }
        [Required,StringLength(80)]
        public string Name { get; set; }
        [Required, StringLength(255)]
        public string Location { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
