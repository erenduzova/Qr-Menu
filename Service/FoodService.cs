using QrMenu.Data;

namespace QrMenu.Service
{
    public class FoodService
    {
        private readonly QrMenuContext _context;

        public FoodService(QrMenuContext context)
        {
            _context = context;
        }

        public void DeleteFoodAndRelatedEntities(int foodId)
        {
            var food = _context.Foods.Find(foodId);
            if (food != null)
            {
                food.StateId = 0;
                _context.Foods.Update(food);
            }
        }

    }
}
