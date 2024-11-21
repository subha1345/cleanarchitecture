using shoppingkart_ui_backend.application.Authentication.Common.Interface.Persistance;
using shoppingkart_ui_backend.domain.Entities;

namespace shoppingkart_ui_backend.infrastructure.Persistance
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new();
        public void Add(User user)
        {
            _users.Add(user);
        }

        public User? GetUserByEmail(string email)
        {
            return _users.SingleOrDefault(u => u.Email == email);
        }
    }
}
