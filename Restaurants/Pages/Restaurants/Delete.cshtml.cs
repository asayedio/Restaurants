using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurant.Data;
using Restaurants.Core;

namespace Restaurants.Pages.Restaurants
{
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        public RestaurantClass Restaurant { get; set; }

        public DeleteModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = restaurantData.GetRestaurantById(restaurantId);
            if (Restaurant == null)
                return RedirectToPage("./NotFound");

            return Page();
        }
        public IActionResult OnPost(int restaurantId)
        {
            Restaurant = restaurantData.DeleteRestaurant(restaurantId);
            restaurantData.Commit();
            if (Restaurant == null)
                return RedirectToPage("./NotFound");
            TempData["Message"] = $"{Restaurant.Name} deleted!";
            return RedirectToPage("./List");
        }
    }
}