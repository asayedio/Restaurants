using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurants.Core;

namespace Restaurants.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly RestaurantsDbContext _context;

        public RestaurantsController(RestaurantsDbContext context)
        {
            _context = context;
        }

        // GET: api/Restaurants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurantClass>>> GetRestaurants()
        {
            return await _context.Restaurants.ToListAsync();
        }

        // GET: api/Restaurants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RestaurantClass>> GetRestaurantClass(int id)
        {
            var restaurantClass = await _context.Restaurants.FindAsync(id);

            if (restaurantClass == null)
            {
                return NotFound();
            }

            return restaurantClass;
        }

        // PUT: api/Restaurants/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestaurantClass(int id, RestaurantClass restaurantClass)
        {
            if (id != restaurantClass.ID)
            {
                return BadRequest();
            }

            _context.Entry(restaurantClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantClassExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Restaurants
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RestaurantClass>> PostRestaurantClass(RestaurantClass restaurantClass)
        {
            _context.Restaurants.Add(restaurantClass);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRestaurantClass", new { id = restaurantClass.ID }, restaurantClass);
        }

        // DELETE: api/Restaurants/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RestaurantClass>> DeleteRestaurantClass(int id)
        {
            var restaurantClass = await _context.Restaurants.FindAsync(id);
            if (restaurantClass == null)
            {
                return NotFound();
            }

            _context.Restaurants.Remove(restaurantClass);
            await _context.SaveChangesAsync();

            return restaurantClass;
        }

        private bool RestaurantClassExists(int id)
        {
            return _context.Restaurants.Any(e => e.ID == id);
        }
    }
}
