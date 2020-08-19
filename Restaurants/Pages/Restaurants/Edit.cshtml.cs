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
        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = restaurantData.GetRestaurantById(restaurantId);
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            if (Restaurant == null)
                return RedirectToPage("./NotFound");

            return Page();
        }

        public IActionResult OnPost()
        {
            restaurantData.UpdateRestaurant(Restaurant);
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            restaurantData.Commit();
            return Page();
        }
    }
}