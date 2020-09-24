using Microsoft.EntityFrameworkCore;
using Restaurants.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Data
{
    public class RestaurantsDbContext : DbContext
    {
        public DbSet<RestaurantClass> Restaurants { get; set; }
    }
}
