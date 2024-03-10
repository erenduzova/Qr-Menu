using QrMenu.Data;
using QrMenu.Models;

namespace QrMenu.Service
{
    public class CategoryService
    {
        private readonly QrMenuContext _context;

        public CategoryService(QrMenuContext context)
        {
            _context = context;
        }
        public void DeleteCategoryAndRelatedEntities(int categoryId)
        {
            var category = _context.Categories.Find(categoryId);

            if (category != null)
            {
                category.StateId = 0;
                _context.Categories.Update(category);

                var foods = _context.Foods.Where(f => f.CategoryId == category.Id).ToList();
                FoodService foodService = new FoodService(_context);
                foreach (var food in foods)
                {
                    foodService.DeleteFoodAndRelatedEntities(food.Id);
                }
            }
        }
    }
}
