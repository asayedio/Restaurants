using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Data;

namespace Restaurants.ViewComponents
{
    public class RestaurantsCountViewComponent : ViewComponent
    {
        private readonly IRestaurantData restaurantData;

        public RestaurantsCountViewComponent(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public IViewComponentResult Invoke()
        {
            var count = restaurantData.GetNumbersOfRestauran();
            return View(count);
        }
    }
}
