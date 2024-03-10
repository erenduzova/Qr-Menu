using QrMenu.Data;

namespace QrMenu.Service
{
    public class CompanyService
    {
        private readonly QrMenuContext _context;

        public CompanyService(QrMenuContext context)
        {
            _context = context;
        }

        public void DeleteCompanyAndRelatedEntities(int companyId)
        {
            var company = _context.Companies.Find(companyId);
            if (company != null)
            {
                company.StateId = 0;
                _context.Companies.Update(company);
                var restaurants = _context.Restaurants.Where(r => r.CompanyId == companyId).ToList();
                RestaurantService restaurantService = new RestaurantService(_context);
                foreach (var restaurant in restaurants)
                {
                    restaurantService.DeleteRestaurantAndRelatedEntities(restaurant.Id);
                }
            }
        }


    }
}
