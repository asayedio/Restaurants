using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Restaurants.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Data
{
    public class RestaurantsDbContext : DbContext
    {
        public RestaurantsDbContext(DbContextOptions<RestaurantsDbContext> options) : base(options)
        {

        }
        public DbSet<RestaurantClass> Restaurants { get; set; }
    }
}
