using shoppingkart_ui_backend.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shoppingkart_ui_backend.application.Authentication.Common.Interface.Persistance
{
    public interface IUserRepository
    {
        void Add(User user);
        User? GetUserByEmail(string email);
    }
}
