using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shoppingkart_ui_backend.application.Authentication.Common.Interface.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Guid id, string firstname, string lastname);
    }
}
