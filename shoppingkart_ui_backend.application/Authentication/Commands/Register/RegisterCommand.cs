using MediatR;
using shoppingkart_ui_backend.application.Services.Authentication.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shoppingkart_ui_backend.application.Authentication.Commands.Register
{
    public record RegisterCommand(
       string FirstName,
       string LastName,
       string Email,
       string Password):IRequest<AuthenticationResult>;
}
