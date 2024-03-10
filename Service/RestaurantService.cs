using QrMenu.Data;
using QrMenu.Models;
using System.ComponentModel.Design;

namespace QrMenu.Service
{
    public class RestaurantService
    {
        private readonly QrMenuContext _context;

        public RestaurantService(QrMenuContext context)
        {
            _context = context;
        }

        public void DeleteRestaurantAndRelatedEntities(int restaurantId)
        {
            var restaurant = _context.Restaurants.Find(restaurantId);
            
            if (restaurant != null)
            {
                restaurant.StateId = 0;
                _context.Restaurants.Update(restaurant);

                var categories = _context.Categories.Where(c => c.RestaurantId == restaurant.Id).ToList();
                CategoryService categoryService = new CategoryService(_context);
                foreach (var category in categories)
                {
                    categoryService.DeleteCategoryAndRelatedEntities(category.Id);
                }
            }
        }
    }
}
