using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Restaurant.Data;
using Restaurants.Core;

namespace Restaurants.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;
        [BindProperty]
        public RestaurantClass Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines{ get; set; }
        public EditModel(IRestaurantData restaurantData , IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? restaurantId)
        {
            if (restaurantId.HasValue)
                Restaurant = restaurantData.GetRestaurantById(restaurantId.Value);
            else
                Restaurant = new RestaurantClass();
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            if (Restaurant == null)
                return RedirectToPage("./NotFound");

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }
            if (Restaurant.ID > 0)
                restaurantData.UpdateRestaurant(Restaurant);
            else
                restaurantData.AddRestaurant(Restaurant);
            restaurantData.Commit();
            TempData["Message"] = "Restaurant saved!";
            return RedirectToPage("./Detail", new { restaurantId = Restaurant.ID });           
        }
    }
}