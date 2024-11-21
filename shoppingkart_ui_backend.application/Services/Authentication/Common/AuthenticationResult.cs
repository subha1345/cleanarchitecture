using shoppingkart_ui_backend.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shoppingkart_ui_backend.application.Services.Authentication.Common
{
    public record AuthenticationResult(
      User User,
      string Token);

}
