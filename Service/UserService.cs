using QrMenu.Data;

namespace QrMenu.Service
{
    public class UserService
    {
        private readonly QrMenuContext _context;

        public UserService(QrMenuContext context)
        {
            _context = context;
        }

        public void DeleteUserAndRelatedEntities(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user != null)
            {
                user.StateId = 0;
                _context.Users.Update(user);
            }
        }

    }
}
