using MediatR;
using shoppingkart_ui_backend.application.Services.Authentication.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shoppingkart_ui_backend.application.Authentication.Queries.Login
{
    public record LoginQuery(
        string Email,
        string Password):IRequest<AuthenticationResult>;
    
}
